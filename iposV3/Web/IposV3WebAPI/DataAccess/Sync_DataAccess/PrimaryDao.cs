using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using IposV3.Model;
using NpgsqlTypes;
using DataAccess;

namespace BIPOS.Database
{
    public class PrimaryDao : BaseDataAccess
    {

        private string? comment;
        private string? devComment;


        public string? Comment { get => comment; set => comment = value; }
        public string? DevComment { get => devComment; set => devComment = value; }



        public PrimaryDao(string? connectionString) : base(connectionString)
        {
        }


        public PrimaryDao(NpgsqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public PrimaryDao(Func<string> connectionMethod):base(connectionMethod)
        {

        }


    }
}
