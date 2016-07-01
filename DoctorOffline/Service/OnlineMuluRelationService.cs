using System;
using DoctorOffline.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
namespace DoctorOffline.Service
{
    public class OnlineMuluRelationService : BaseService
    {
        public void Add(OnlineMuluRelation relation)
        {
            MySqlConnection con = GetConnection();
            con.Execute(String.Format(@"insert into onlinemulurelation (OnlineMuluId,Ask120Relation,FHRelation,JJRelation,JKRelation,SJRelation) 
                                    values({0}, '{1}', '{2}', '{3}', '{4}', '{5}')", 
                relation.OnlineMuluId, relation.Ask120Relation, relation.FHRelation,relation.JJRelation,relation.JKRelation,relation.SJRelation));
        }
        public void Update(OnlineMuluRelation relation)
        {
            MySqlConnection con = GetConnection();
            con.Execute(String.Format(@"update onlinemulurelation set Ask120Relation='{0}',
                        FHRelation='{1}',JJRelation='{2}',JKRelation='{3}',SJRelation='{4}'", relation.Ask120Relation, relation.FHRelation, relation.JJRelation, relation.JKRelation, relation.SJRelation));
        }

        public List<OnlineMuluRelation> GetByOnlineMuluId(long onlineMuluId)
        {
            MySqlConnection con = GetConnection();
            String sql = String.Format("select * from  onlinemulurelation where OnlineMuluId={0}", onlineMuluId);
            var muluList = con.Query<OnlineMuluRelation>(sql).AsList<OnlineMuluRelation>();
            return muluList;
        }
        public void Save(OnlineMuluRelation relation)
        {
            var relationList = GetByOnlineMuluId(relation.OnlineMuluId);
            if(relationList!=null && relationList.Count > 0)
            {
                Update(relation);
            }else
            {
                Add(relation);
            }
        }
    }
}
