﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            _userDal.GetAll();
            return new SuccessDataResult<List<User>>(Messages.UsersListed);
        }

        public IDataResult<List<User>> GetById(int id)
        {
            _userDal.Get(u => u.UserId == id);
            return new SuccessDataResult<List<User>>(Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
