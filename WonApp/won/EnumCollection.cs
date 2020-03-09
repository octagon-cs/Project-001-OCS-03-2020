

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace won
{

    public enum PermohonanType
    {
         Pengantar_KTP , Pengantar_KK , Tidak_Mampu , Keterangan_Domisili , Keterangan_SKCK , Keterangan_Usaha ,
		 Penguasaan_Tanah , Keterangan_Desa , Keterangan_Cerai , Keterangan_eKTP , Keterangan_Nikah , Kelahiran , Sudah_Menikah ,
		 Belum_Menikah , Kematian , Keterangan_Lainnya , Pindah
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusPersetujuan{
       Diterima, Disetujui,Dikembalikan, Selesai, Ditolak,
        Baru,
        None
    }


    public enum ProgressRole{
        Pemohon, Admin, Seklur, Lurah
    }



    public enum PositionNode
    {
       Middle, Start,  End, 
    }


}