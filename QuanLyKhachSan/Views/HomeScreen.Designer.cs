namespace QuanLyKhachSan.Views
{
    partial class HomeScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnListBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.btnListCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửĐặtPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem,
            this.thanhToánToolStripMenuItem,
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1368, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.quảnLýPhòngToolStripMenuItem,
            this.kháchHàngToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.management_3429694;
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 24);
            this.toolStripMenuItem1.Text = "Đặt phòng";
            // 
            // quảnLýPhòngToolStripMenuItem
            // 
            this.quảnLýPhòngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiPhòngToolStripMenuItem});
            this.quảnLýPhòngToolStripMenuItem.Name = "quảnLýPhòngToolStripMenuItem";
            this.quảnLýPhòngToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.quảnLýPhòngToolStripMenuItem.Text = "Phòng";
            // 
            // loạiPhòngToolStripMenuItem
            // 
            this.loạiPhòngToolStripMenuItem.Name = "loạiPhòngToolStripMenuItem";
            this.loạiPhòngToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.loạiPhòngToolStripMenuItem.Text = "Loại phòng";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnListBooking,
            this.btnListCustomer});
            this.danhMụcToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.options;
            this.danhMụcToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.danhMụcToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // btnListBooking
            // 
            this.btnListBooking.Image = global::QuanLyKhachSan.Properties.Resources.to_do_list;
            this.btnListBooking.Name = "btnListBooking";
            this.btnListBooking.Size = new System.Drawing.Size(212, 24);
            this.btnListBooking.Text = "Danh sách đặt phòng";
            // 
            // btnListCustomer
            // 
            this.btnListCustomer.Image = global::QuanLyKhachSan.Properties.Resources.customer;
            this.btnListCustomer.Name = "btnListCustomer";
            this.btnListCustomer.Size = new System.Drawing.Size(212, 24);
            this.btnListCustomer.Text = "Danh sách khách hàng";
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lịchSửĐặtPhòngToolStripMenuItem,
            this.lịchSửThanhToánToolStripMenuItem});
            this.báoCáoThốngKêToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.bar_graph_151855;
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo thống kê";
            // 
            // lịchSửĐặtPhòngToolStripMenuItem
            // 
            this.lịchSửĐặtPhòngToolStripMenuItem.Name = "lịchSửĐặtPhòngToolStripMenuItem";
            this.lịchSửĐặtPhòngToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.lịchSửĐặtPhòngToolStripMenuItem.Text = "Lịch sử đặt phòng";
            // 
            // lịchSửThanhToánToolStripMenuItem
            // 
            this.lịchSửThanhToánToolStripMenuItem.Name = "lịchSửThanhToánToolStripMenuItem";
            this.lịchSửThanhToánToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.lịchSửThanhToánToolStripMenuItem.Text = "Lịch sử thanh toán";
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.operation_3080541;
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.settings_3067451;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::QuanLyKhachSan.Properties.Resources.logout_3889524;
            this.đăngXuấtToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 891);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnListBooking;
        private System.Windows.Forms.ToolStripMenuItem btnListCustomer;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loạiPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửĐặtPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửThanhToánToolStripMenuItem;
    }
}