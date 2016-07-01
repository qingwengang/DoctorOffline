
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DoctorOffline.Entity;
using DoctorOffline.Models;
using MySql.Data.MySqlClient;

namespace DoctorOffline.Service
{
    public class OnlineMuluService : BaseService
    {
        public List<OnlineMulu> getMuluList()
        {
            MySqlConnection con = new MySqlConnection("Data Source=127.0.0.1;Initial Catalog=doctor;Persist Security Info=True;User ID=root;Password=ganggang");
            String sql = "select * from onlinemulu";
            List<OnlineMulu> muluList= con.Query<OnlineMulu>(sql).ToList<OnlineMulu>();
            return muluList;
        }

        public List<MuluModel> getMuluModel(){
            var muluModelList = new List<MuluModel>();
            getMuluModelById(0);
            return muluModelList;
        }
        public MuluModel getMuluModelById(long muluId)
        {
            var mulus = GetAll();
            return GetMuluModel(mulus, muluId);
        }
        public MuluModel getMuluDetail(long muluId){
            var muluModelList = new List<MuluModel>();
            MySqlConnection con = new MySqlConnection("Data Source=127.0.0.1;Initial Catalog=doctor;Persist Security Info=True;User ID=root;Password=ganggang");
            String sql = String.Format("select * from onlinemulu where id={0} or parentid={0}",muluId);
            var muluList= con.Query<OnlineMulu>(sql).ToList<OnlineMulu>();
            if(muluList!=null && muluList.Count()>0){
                MuluModel mm=new MuluModel();
                mm.mulu=muluList.Where(x=>x.Id==muluId).FirstOrDefault();
                //mm.children=muluList.Where(x=>x.ParentId==muluId).ToList();
                return mm;
            }
            return null;
        }
        public void AddMulu(OnlineMulu mulu)
        {
            MySqlConnection con = GetConnection();
            con.Execute(String.Format("insert into onlinemulu (name,level,parentid) VALUES('{0}',{1},{2})",mulu.Name,mulu.Level,mulu.ParentId));
        }
        
        public List<OnlineMulu> GetAll()
        {
            MySqlConnection con = GetConnection();
            String sql = "select * from onlinemulu";
            var muluList = con.Query<OnlineMulu>(sql).ToList<OnlineMulu>();
            return muluList;
        }

        public MuluModel GetMuluModel(List<OnlineMulu> muluList,long muluId)
        {
            MuluModel model = new MuluModel();
            if (muluId == 0)
            {
                model.MuluName = "Root";
                model.Level = 0;
                model.ParentId = -1;
                model.MuluId = 0;
            }else
            {
                OnlineMulu mulu = muluList.Where(x => x.Id == muluId).FirstOrDefault();
                model.MuluName = mulu.Name;
                model.Level = mulu.Level;
                model.ParentId = mulu.ParentId;
                model.MuluId = muluId;
            }
            var children = muluList.Where(x => x.ParentId == muluId);
            if (muluList.Where(x => x.ParentId == muluId).Count() > 0)
            {
                foreach(var item in children)
                {
                    model.children.Add(GetMuluModel(muluList, item.Id));
                }
            }else
            {
                model.children = null;
            }
            return model;
        }
    }
}