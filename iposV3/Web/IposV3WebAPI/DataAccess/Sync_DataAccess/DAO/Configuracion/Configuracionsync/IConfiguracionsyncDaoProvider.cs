
using BIPOS.Database.DAO;
using IposV3.Model.Syncr;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    

    public interface IConfiguracionsyncDaoProvider : ISerializationDaoProvider<Configuracionsync, ConfiguracionsyncParam>
    {
    }
}
