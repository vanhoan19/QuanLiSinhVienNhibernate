using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace QuanLiSinhVien.Models
{
    public class KetQuaCompositeKey
    {
        public virtual string MaSV { get; set; }
        public virtual string MaMH { get; set; }
        public KetQuaCompositeKey()
        {
            
        }
        public KetQuaCompositeKey(string maSV, string maMH)
        {
            MaSV = maSV;
            MaMH = maMH;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            KetQuaCompositeKey other = (KetQuaCompositeKey)obj;
            return MaSV == other.MaSV && MaMH == other.MaMH;
        }

        // Ghi đè phương thức GetHashCode()
        public override int GetHashCode()
        {
            return MaSV.GetHashCode() ^ MaMH.GetHashCode();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

    }
}