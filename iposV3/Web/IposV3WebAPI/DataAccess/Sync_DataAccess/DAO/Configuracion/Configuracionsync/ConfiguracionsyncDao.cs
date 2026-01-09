using BIPOS.Database.DAO;
using IposV3.Model.Syncr;
using DataAccess;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIPOS.Database.DAO
{

    public class ConfiguracionsyncDao : BaseSerializationDao<Configuracionsync, ConfiguracionsyncParam>, IConfiguracionsyncDaoProvider
    {

        protected override void PutDataLocation()
        {

            this.FileName = Environment.CurrentDirectory + "\\systemdata\\configuracionsync.xml";
        }


        public override List<Configuracionsync> SelectList(SerializationTransaction? st, ConfiguracionsyncParam? param, IposV3.Model.KendoParams? kendoParams)
        {

            return base.SelectList(null, null, null).OrderBy(y => y.Id).ToList();
        }

        public override bool Insert(Configuracionsync item, SerializationTransaction? transaction)
        {
            bool result = base.Insert(item, transaction);


            return result;

        }



        public override bool Delete(Configuracionsync item, SerializationTransaction? transaction)
        {

            bool result = base.Delete(item, transaction);
            return result;
        }
        public override bool Update(Configuracionsync item, SerializationTransaction? transaction)
        {

            bool result = base.Update(item, transaction);
            return result;
        }
    }
}
