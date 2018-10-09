using DevExpress.XtraScheduler;
using System.Windows.Forms;

namespace TimelineTimeScales {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.TimeDisplayType = AppointmentTimeDisplayType.Text;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
            #region #changescales
            TimeScaleCollection scales = schedulerControl1.TimelineView.Scales;

            scales.BeginUpdate();
            try {
                scales.Clear();
                scales.Add(new CustomTimeScaleDay());
                scales.Add(new CustomTimeScaleHour());
            } finally {
                scales.EndUpdate();
            }
            #endregion #changescales

        }
    }
}