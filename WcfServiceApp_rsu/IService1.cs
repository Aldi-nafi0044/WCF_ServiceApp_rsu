using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApp_rsu
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string insertdata_pasien(string id_pasien, string nik, string nama_pasien, string tempat_lahir, string tgl_lahir, string agama, string jns_kelamin, string alamat, string no_telpon);

        [OperationContract]
        string editdata_pasien(string id_pasien, string nik, string nama_pasien, string tempat_lahir, string tgl_lahir, string agama, string jns_kelamin, string alamat, string no_telpon);

        [OperationContract]
        string deletedata_pasien(string id_pasien);

        [OperationContract]
        List<view_data> caridata_pasien(string id_pasien);

        [OperationContract]
        List<view_data> listdata_pasien();

    }


    [DataContract]
    public class view_data
    {
        [DataMember]
        public string id_pasien { get; set; }
        [DataMember]
        public string nik { get; set; }
        [DataMember]
        public string nama_pasien { get; set; }
        [DataMember]
        public string agama { get; set; }
        [DataMember]
        public string jns_kelamin { get; set; }
        [DataMember]
        public string no_telpon { get; set; }
        [DataMember]
        public string alamat { get; set; }
        [DataMember]
        public string tempat_lahir { get; set; }
        [DataMember]
        public string tgl_lahir { get; set; }
    }
}
