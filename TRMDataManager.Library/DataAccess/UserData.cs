using System.Collections.Generic;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            var sql = new SqlDataAccess();

            var p = new { Id = Id };

            // Dynamic should work in the same assembly, but not others (maybe)
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "TRMData");

            return output;
        }
    }
}