using System;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace TimelineTimeScales {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            TimeScaleCollection scales = schedulerControl1.TimelineView.Scales;

            scales.BeginUpdate();
            try {
                scales.Clear();
                scales.Add(new CustomTimeScaleDay());
                scales.Add(new CustomTimeScaleHour());
            } finally {
                scales.EndUpdate();
            }

        }
    }
}