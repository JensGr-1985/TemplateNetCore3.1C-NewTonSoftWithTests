using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore3._1WithSwagger.DbAccess;
using WebApiCore3._1WithSwagger.Repository.DbAccess.Interface;

namespace WebApiCore3._1WithSwagger.Repository
{
    public class ClassThatContainsMethodWeWannaTest
    {
        private readonly IDbAccess _db;

        public ClassThatContainsMethodWeWannaTest(IDbAccess db)
        {
            _db = db;
        }

        public int MethodweGonnaTest(int ParameterIAmPassingthruSql)
        {
            var myparams=new List<SqlParam>();
            myparams.Add(new SqlParam("myParameter",1,System.Data.DbType.Int16));
            return _db.Query<int>("select * from theAwesomeTable where 1=@myParameter",myparams).First();
        }
    }
}
