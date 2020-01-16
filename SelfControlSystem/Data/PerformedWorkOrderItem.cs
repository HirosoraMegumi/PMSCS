using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfControlSystem.Data
{
    public class PerformedWorkOrderItem
    {

        /// <summary>
        /// 社員ID
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// 実施日
        /// </summary>
        /// <remarks>
        /// 実施日は作業開始から帰宅するまで日付をまたいでいても変わらない。
        /// </remarks>
        public DateTime PerformedDate { get; set; }

        /// <summary>
        /// 実施作業ID
        /// </summary>
        public int PerformedWorkOrderID { get; set; }

        /// <summary>
        /// 作業オーダーID
        /// </summary>
        public string WorkOrderID { get; set; }

        /// <summary>
        /// 作業オーダー情報
        /// </summary>
        public Data.WorkOrderItem WorkOrderInfo { get; set; }

        /// <summary>
        /// 作業開始日時
        /// </summary>
        public DateTime WorkStartDateTime { get; set; }

        /// <summary>
        /// 作業終了日時
        /// </summary>
        public DateTime? WorkEndDateTime { get; set; }

        /// <summary>
        /// 作業時間(H)
        /// </summary>
        /// <remarks>
        /// 作業終了日時がnullの場合は"-1"を返す。昼休憩(12:00～13:00)は含まない。
        /// </remarks>
        public float WorkTime
        {
            get
            {
                float result = 0;
                if (WorkEndDateTime != null)
                {
                    DateTime bufStartDateTime = this.WorkStartDateTime;
                    DateTime bufEndDateTime = Convert.ToDateTime(this.WorkEndDateTime);
                   
                    TimeSpan ts = bufEndDateTime - bufStartDateTime;
                    // 作業時間(H)
                    result = Convert.ToSingle(ts.TotalHours);
                }
                else
                {
                    result = -1;
                }
                return result;
            }
        }

        /// <summary>
        /// 作業管理表用 作業時間(0.05H単位)
        /// </summary>
        /// <remarks>
        /// 作業管理表に入力する値。
        /// </remarks>
        public float ConvertWorkTime { get; set; }


    }
}
