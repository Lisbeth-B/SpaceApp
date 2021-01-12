using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using SpaceApp.Entity;
using SpaceApp.Models.Register;
using SpaceApp.Models.Update;

namespace SpaceApp.Models
{
    public class UserService : IUserService
    {
        private UserContext _context;
        private readonly IMapper _mapper;

        public UserService(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User Register(RegisterModel model)
        {
            RegisterValidator validator = new RegisterValidator(_context);
            validator.ValidateAndThrow(model);

            User user = _mapper.Map<User>(model);
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (model.IsWorker == true)
            {
                Worker worker = new Worker(model.IdNumber, model.Salary.Value);
                _context.Workers.Add(worker);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }


        public User Login(LoginModel model)
        {
            LoginValidator validator = new LoginValidator(_context);
            validator.ValidateAndThrow(model);

            User user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public void UpdateIsMarried(UpdateIsMarriedModel model)
        {
            UpdateIsMarriedValidator validator = new UpdateIsMarriedValidator();
            validator.ValidateAndThrow(model);

            User user = _context.Users.Find(model.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.IsMarried == model.IsMarried)
            {
                return;
            }

            user.IsMarried = model.IsMarried.Value;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void UpdateIsWorker(UpdateIsWorkerModel model)
        {
            UpdateIsWorkerValidator validator = new UpdateIsWorkerValidator();
            validator.ValidateAndThrow(model);

            User user = _context.Users.Find(model.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (model.IsWorker == false && user.IsWorker == true)
            {
                user.IsWorker = false;
                Worker worker = _context.Workers.SingleOrDefault(u => u.IdNumber == user.IdNumber);

                if (worker != null)
                {
                    _context.Workers.Remove(worker);

                }
                _context.Users.Update(user);
                _context.SaveChanges();
            }

            if (model.IsWorker == true && user.IsWorker == false)
            {
                user.IsWorker = true;
                Worker worker = new Worker(user.IdNumber, model.Salary.Value);

                _context.Users.Update(user);
                _context.Workers.Add(worker);
                _context.SaveChanges();
            }

            if (model.IsWorker == true && user.IsWorker == true)
            {

                Worker worker = _context.Workers.SingleOrDefault(u => u.IdNumber == user.IdNumber);
                worker.Salary = model.Salary.Value;

                _context.SaveChanges();
            }
        }

        public void UpdateAddress(UpdateAddressModel model)
        {
            UpdateAddressValidator validator = new UpdateAddressValidator();
            validator.ValidateAndThrow(model);

            User user = _context.Users.Find(model.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Address == model.Address)
            {
                return;
            }

            user.Address = model.Address;

            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            Worker worker = _context.Workers.SingleOrDefault(u => u.IdNumber == user.IdNumber);

            if (worker != null)
            {
                _context.Workers.Remove(worker);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
