using BIPOS.Database;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3WebAPI.Services
{
    public class TestingService
    {



        public int TestInPG()
        {

            //var postgreConnectionStr = "Server=iposstaging.cg3tvdqx9zns.us-east-1.rds.amazonaws.com;Port=5432;Database=ipos_test_ramos;Uid=postgres;Pwd=Twincept.l";
            var postgreConnectionStr = "Server=host.docker.internal;Port=5432;Database=ipos_test_ramos;User Id=postgres;Password=Twincept.l;";
            BaseDataAccess dao = new BaseDataAccess(postgreConnectionStr);


            List<System.Data.Common.DbParameter> dbParameters = new List<System.Data.Common.DbParameter>();

            int recordCount = 0;

            var existRecordQuery = $"Select count(*) coun from \"Docto\"  ";

            using (var dataReader = dao.GetDataReader(existRecordQuery, dbParameters, System.Data.CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        recordCount = dataReader.GetInt32(0);
                    }
                }
            }
            return recordCount;
        }

    }
}
