using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Peopel
    {
        public int Id { get; set; }  
        public string code { get; set; }//编号
        public string name { get; set; }//名称
        public string simCode { get; set; }//简码
        public string IdCard { get; set; }//身份证
        public string birthday { get; set; }//出生日期
        public string sex { get; set; }//性别
        public string national { get; set; }//民族
        public string workDate { get; set; }//工作日期
        public string officeTel { get; set; }//办公室电话
        public string email { get; set; } //email
        public string category { get; set; }//执业类别
        public string praScope { get; set; } //执业范围 Scope of practice
        public string manaPos { get; set; } //管理职务 Management position
        public string professPos { get; set; }//专业技术职务 Professional and technical position
        public string empPos { get; set; }//聘任技术职务 employment technical positions
        public string education { get; set; } //学历   
        public string major { get; set; }//所学专业
        public string abordTime { get; set; }//留学时间
        public string abordChannel { get; set; }//留学渠道
        public string training { get; set; }//接受培训
        public string 科研课题 { get; set; }//科研课题 Scientific research subject
        public string profile { get; set; }//个人简介  Personal profile
        public string createTime { get; set; }//建档时间
        public string deleteTime { get; set; }//撤档时间
        public string deleteReason { get; set; }//撤档愿意
        public string otherName { get; set; }//别名
        public string site { get; set; }//站点
        public string sign { get; set; }//签名
        public string signPic { get; set; }//签名图片
        public string praNum { get; set; }//Practice number执业证号
        public string cerNum { get; set; }//资格证书号 Certificate number
        public string praStartTime { get; set; }//执业开始日期 Practice start time
        public string presSign { get; set; }//处方权标志 prescription sign
        public string OperLevel { get; set; }//手术等级 Operation level
        public string mobile { get; set; }//手机
        public string lastTime { get; set; }//最后修改时间
        public string sort { get; set; }//顺序
        public string outRight { get; set; }//门诊特殊医嘱权限  outpatient service 
        public string inRight { get; set; }//住院特殊医嘱权限 Permission for special inpatient orders
        public string accExpDate { get; set; }//账号到期时间 Account expiry date

    }
}
