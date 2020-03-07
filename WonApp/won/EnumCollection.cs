

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace won
{

    public enum PermohonanType
    {
        Cerai, Pindah, Nikah, TidakMampu, Meninggal, SKCK
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusPersetujuan{
       Diterima, Disetujui,Dikembalikan, Selesai, Ditolak,
        Baru
    }


    public enum ProgressRole{
        Pemohon,Admin,SekertarisLurah, Lurah
    }
    
}