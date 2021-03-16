using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int userId);
        
        //IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        
        List<OperationClaim> GetClaims(User user);
        
        void Add(User user);
        User GetByMail(string email);
        

    }
}
