using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.SuratPermohonan
{
    public class Tanahmodel : BaseNotify
    {

        private int _NIK;


        [JsonProperty("nik")]
        public int NIK
        {
            get { return _NIK; }
            set { SetProperty(ref _NIK, value); }
        }

        private string _Nama;


        [JsonProperty("nama")]
        public string Nama
        {
            get { return _Nama; }
            set { SetProperty(ref _Nama, value); }
        }
        private int _NoSurat;


        [JsonProperty("nosurat")]
        public int NoSurat
        {
            get { return _NoSurat; }
            set { SetProperty(ref _NoSurat, value); }
        }
        // private string _FootCetak;


        // [JsonProperty("footcetak")]
        // public string FootCetak
        // {
        //     get { return _FootCetak; }
        //     set { SetProperty(ref _FootCetak, value); }
        // }
    
        private string _SebidangTanah;

        [JsonProperty("sebidangtanah")]
        public string SebidangTanah
        {
            get { return _SebidangTanah; }
            set { SetProperty(ref _SebidangTanah, value); }
        }

        private string _Luas;

        [JsonProperty("sebidangtanah")]
        public string Luas
        {
            get { return _Luas; }
            set { SetProperty(ref _Luas, value); }
        }

        private string _DigunakanUntuk;


        [JsonProperty("digunakanuntuk")]
        public string DigunakanUntuk
        {
            get { return _DigunakanUntuk; }
            set { SetProperty(ref _DigunakanUntuk, value); }
        }
        private string _SebelahUtara;


        [JsonProperty("sebelahutara")]
        public string SebelahUtara
        {
            get { return _SebelahUtara; }
            set { SetProperty(ref _SebelahUtara, value); }
        }
        private string _SebelahSelatan;


        [JsonProperty("sebelahselatan")]
        public string SebelahSelatan
        {
            get { return _SebelahSelatan; }
            set { SetProperty(ref _SebelahSelatan, value); }
        }
        private string _SebelahTimur;


        [JsonProperty("sebelahtimur")]
        public string SebelahTimur
        {
            get { return _SebelahTimur; }
            set { SetProperty(ref _SebelahTimur, value); }
        }
        private string _SebelahBarat;


        [JsonProperty("sebelahbarat")]
        public string SebelahBarat
        {
            get { return _SebelahBarat; }
            set { SetProperty(ref _SebelahBarat, value); }
        }
         private string _TerjadiPadaTahun;


        [JsonProperty("terjadipadatahun")]
        public string TerjadiPadaTahun
        {
            get { return _TerjadiPadaTahun; }
            set { SetProperty(ref _TerjadiPadaTahun, value); }
        }
         private string _DiusahakanSebagai;


        [JsonProperty("diusahakansebagai")]
        public string DiusahakanSebagai
        {
            get { return _DiusahakanSebagai; }
            set { SetProperty(ref _DiusahakanSebagai, value); }
        }
        public override bool Valid
        {
            get
            {
                return Validation();

            }
        }

        private bool Validation()
        {
            var valid = true;
            if (NIK<=0 || string.IsNullOrEmpty(Nama) || NoSurat<=0 || string.IsNullOrEmpty(SebidangTanah) || string.IsNullOrEmpty(Luas) || string.IsNullOrEmpty(DigunakanUntuk) || string.IsNullOrEmpty(SebelahUtara) || string.IsNullOrEmpty(SebelahSelatan) || string.IsNullOrEmpty(SebelahTimur) || string.IsNullOrEmpty(SebelahBarat) || string.IsNullOrEmpty(TerjadiPadaTahun) || string.IsNullOrEmpty(DiusahakanSebagai))
            {
                valid = false;
                ErrorMessage = "Data Tidak Boleh Kosong";
            }

            // if (Password != ConfirmPassword)
            // {
            //     valid = false;
            //     ErrorMessage = "Email dan Password Tidak Sama";
            // }
            // const string pattern = @"^(? !\.)(""([^""\r\\] |\\[""\r\\])*""|" + @"([-a - z0 - 9!#$%&’*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            // var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // if (regex.IsMatch(Email))
            // {
            //     ErrorMessage = "Email Anda Tidak Valid";valid = false;
            // }

            if (valid) ErrorMessage = "";
            return valid;
        }
    }
    
}