namespace Tekidoni
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.defaultButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.startStopButton = new System.Windows.Forms.Button();
            this.keywordPrefixTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.keywordSuffixTextBox = new System.Windows.Forms.TextBox();
            this.weatherSuffixTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.weatherPrefixTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.おまけOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左上付き運営コメントToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordSampleTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.timeLeftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.aliveLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.weatherSampleTextBox = new System.Windows.Forms.TextBox();
            this.weatherMiddleComboBox = new System.Windows.Forms.ComboBox();
            this.keywordNotFoundTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.weatherNotDayTextBox = new System.Windows.Forms.TextBox();
            this.weatherNotCityTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.successSuffixTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLeftNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultButton
            // 
            this.defaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.defaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultButton.Location = new System.Drawing.Point(356, 274);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(75, 23);
            this.defaultButton.TabIndex = 0;
            this.defaultButton.Text = "既定値";
            this.toolTip.SetToolTip(this.defaultButton, "既定値に戻します。\r\n保存ボタンを押すまで保存されません。");
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(275, 274);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "保存";
            this.toolTip.SetToolTip(this.saveButton, "検索のフォーマットを保存します。\r\n次回起動時に引き継がれます。");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Location = new System.Drawing.Point(356, 245);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "読み込み";
            this.toolTip.SetToolTip(this.loadButton, "保存している状態に戻します。");
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 36;
            // 
            // startStopButton
            // 
            this.startStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startStopButton.Location = new System.Drawing.Point(12, 274);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(75, 23);
            this.startStopButton.TabIndex = 6;
            this.startStopButton.Text = "起動";
            this.toolTip.SetToolTip(this.startStopButton, "けんさくさんの起動・停止を操作します。");
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // keywordPrefixTextBox
            // 
            this.keywordPrefixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keywordPrefixTextBox.Location = new System.Drawing.Point(12, 50);
            this.keywordPrefixTextBox.Name = "keywordPrefixTextBox";
            this.keywordPrefixTextBox.Size = new System.Drawing.Size(100, 19);
            this.keywordPrefixTextBox.TabIndex = 13;
            this.keywordPrefixTextBox.Text = "検索";
            this.keywordPrefixTextBox.TextChanged += new System.EventHandler(this.keywordPrefixTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "「";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(126, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "<キーワード>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "」";
            // 
            // keywordSuffixTextBox
            // 
            this.keywordSuffixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keywordSuffixTextBox.Location = new System.Drawing.Point(207, 50);
            this.keywordSuffixTextBox.Name = "keywordSuffixTextBox";
            this.keywordSuffixTextBox.Size = new System.Drawing.Size(100, 19);
            this.keywordSuffixTextBox.TabIndex = 18;
            this.keywordSuffixTextBox.TextChanged += new System.EventHandler(this.keywordSuffixTextBox_TextChanged);
            // 
            // weatherSuffixTextBox
            // 
            this.weatherSuffixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherSuffixTextBox.Location = new System.Drawing.Point(331, 144);
            this.weatherSuffixTextBox.Name = "weatherSuffixTextBox";
            this.weatherSuffixTextBox.Size = new System.Drawing.Size(100, 19);
            this.weatherSuffixTextBox.TabIndex = 24;
            this.weatherSuffixTextBox.TextChanged += new System.EventHandler(this.weatherSuffixTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "」";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(119, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "地域名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "「";
            // 
            // weatherPrefixTextBox
            // 
            this.weatherPrefixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherPrefixTextBox.Location = new System.Drawing.Point(12, 144);
            this.weatherPrefixTextBox.Name = "weatherPrefixTextBox";
            this.weatherPrefixTextBox.Size = new System.Drawing.Size(100, 19);
            this.weatherPrefixTextBox.TabIndex = 20;
            this.weatherPrefixTextBox.Text = "天気";
            this.weatherPrefixTextBox.TextChanged += new System.EventHandler(this.weatherPrefixTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "」";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(219, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "(今日|明日|明後日)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "「";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "同一IDでの検索間隔";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(165, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "秒";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.おまけOToolStripMenuItem,
            this.ヘルプhToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(446, 24);
            this.menuStrip.TabIndex = 31;
            this.menuStrip.Text = "menuStrip";
            // 
            // おまけOToolStripMenuItem
            // 
            this.おまけOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.左上付き運営コメントToolStripMenuItem});
            this.おまけOToolStripMenuItem.Name = "おまけOToolStripMenuItem";
            this.おまけOToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.おまけOToolStripMenuItem.Text = "おまけ(&O)";
            // 
            // 左上付き運営コメントToolStripMenuItem
            // 
            this.左上付き運営コメントToolStripMenuItem.Name = "左上付き運営コメントToolStripMenuItem";
            this.左上付き運営コメントToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.左上付き運営コメントToolStripMenuItem.Text = "左上付き運営コメント(&H)";
            this.左上付き運営コメントToolStripMenuItem.Click += new System.EventHandler(this.左上付き運営コメントToolStripMenuItem_Click);
            // 
            // ヘルプhToolStripMenuItem
            // 
            this.ヘルプhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョン情報ToolStripMenuItem});
            this.ヘルプhToolStripMenuItem.Name = "ヘルプhToolStripMenuItem";
            this.ヘルプhToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ヘルプhToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報(&V)";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // keywordSampleTextBox
            // 
            this.keywordSampleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keywordSampleTextBox.Location = new System.Drawing.Point(83, 74);
            this.keywordSampleTextBox.Name = "keywordSampleTextBox";
            this.keywordSampleTextBox.ReadOnly = true;
            this.keywordSampleTextBox.Size = new System.Drawing.Size(348, 19);
            this.keywordSampleTextBox.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "検索例";
            // 
            // timeLeftNumericUpDown
            // 
            this.timeLeftNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeLeftNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLeftNumericUpDown.Location = new System.Drawing.Point(120, 247);
            this.timeLeftNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.timeLeftNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeLeftNumericUpDown.Name = "timeLeftNumericUpDown";
            this.timeLeftNumericUpDown.ReadOnly = true;
            this.timeLeftNumericUpDown.Size = new System.Drawing.Size(40, 19);
            this.timeLeftNumericUpDown.TabIndex = 34;
            this.timeLeftNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeLeftNumericUpDown.ValueChanged += new System.EventHandler(this.timeLeftNumericUpDown_ValueChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(182, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 35;
            this.label15.Text = "(10 ～ 60)";
            // 
            // aliveLabel
            // 
            this.aliveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aliveLabel.AutoSize = true;
            this.aliveLabel.Location = new System.Drawing.Point(93, 279);
            this.aliveLabel.Name = "aliveLabel";
            this.aliveLabel.Size = new System.Drawing.Size(85, 12);
            this.aliveLabel.TabIndex = 37;
            this.aliveLabel.Text = "現在停止中です";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "検索例";
            // 
            // weatherSampleTextBox
            // 
            this.weatherSampleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherSampleTextBox.Location = new System.Drawing.Point(83, 169);
            this.weatherSampleTextBox.Name = "weatherSampleTextBox";
            this.weatherSampleTextBox.ReadOnly = true;
            this.weatherSampleTextBox.Size = new System.Drawing.Size(348, 19);
            this.weatherSampleTextBox.TabIndex = 38;
            // 
            // weatherMiddleComboBox
            // 
            this.weatherMiddleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weatherMiddleComboBox.FormattingEnabled = true;
            this.weatherMiddleComboBox.Items.AddRange(new object[] {
            "",
            "の",
            "／",
            "｜",
            "・"});
            this.weatherMiddleComboBox.Location = new System.Drawing.Point(171, 143);
            this.weatherMiddleComboBox.Name = "weatherMiddleComboBox";
            this.weatherMiddleComboBox.Size = new System.Drawing.Size(39, 20);
            this.weatherMiddleComboBox.TabIndex = 42;
            this.weatherMiddleComboBox.SelectedIndexChanged += new System.EventHandler(this.weatherMiddleComboBox_SelectedIndexChanged);
            // 
            // keywordNotFoundTextBox
            // 
            this.keywordNotFoundTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keywordNotFoundTextBox.Location = new System.Drawing.Point(83, 99);
            this.keywordNotFoundTextBox.Name = "keywordNotFoundTextBox";
            this.keywordNotFoundTextBox.Size = new System.Drawing.Size(348, 19);
            this.keywordNotFoundTextBox.TabIndex = 43;
            this.keywordNotFoundTextBox.TextChanged += new System.EventHandler(this.keywordNotFoundTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 44;
            this.label16.Text = "検索失敗時";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(8, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 93);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "キーワード検索フォーマット";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.weatherNotDayTextBox);
            this.groupBox2.Controls.Add(this.weatherNotCityTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 94);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "お天気検索フォーマット";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(217, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 50;
            this.label17.Text = "予報日不正";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "地域名不正";
            // 
            // weatherNotDayTextBox
            // 
            this.weatherNotDayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherNotDayTextBox.Location = new System.Drawing.Point(288, 67);
            this.weatherNotDayTextBox.Name = "weatherNotDayTextBox";
            this.weatherNotDayTextBox.Size = new System.Drawing.Size(135, 19);
            this.weatherNotDayTextBox.TabIndex = 48;
            this.weatherNotDayTextBox.TextChanged += new System.EventHandler(this.weatherNotDayTextBox_TextChanged);
            // 
            // weatherNotCityTextBox
            // 
            this.weatherNotCityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherNotCityTextBox.Location = new System.Drawing.Point(75, 67);
            this.weatherNotCityTextBox.Name = "weatherNotCityTextBox";
            this.weatherNotCityTextBox.Size = new System.Drawing.Size(135, 19);
            this.weatherNotCityTextBox.TabIndex = 47;
            this.weatherNotCityTextBox.TextChanged += new System.EventHandler(this.weatherNotCityTextBox_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 45;
            this.label18.Text = "成功時接尾後";
            // 
            // successSuffixTextBox
            // 
            this.successSuffixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.successSuffixTextBox.Location = new System.Drawing.Point(83, 222);
            this.successSuffixTextBox.Name = "successSuffixTextBox";
            this.successSuffixTextBox.Size = new System.Drawing.Size(135, 19);
            this.successSuffixTextBox.TabIndex = 47;
            this.successSuffixTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 310);
            this.Controls.Add(this.successSuffixTextBox);
            this.Controls.Add(this.keywordNotFoundTextBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.weatherMiddleComboBox);
            this.Controls.Add(this.weatherSampleTextBox);
            this.Controls.Add(this.aliveLabel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.timeLeftNumericUpDown);
            this.Controls.Add(this.keywordSampleTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.weatherSuffixTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.weatherPrefixTextBox);
            this.Controls.Add(this.keywordSuffixTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keywordPrefixTextBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "けんさくさん for NCV(EA)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLeftNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button defaultButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button startStopButton;
		private System.Windows.Forms.TextBox keywordPrefixTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox keywordSuffixTextBox;
		private System.Windows.Forms.TextBox weatherSuffixTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox weatherPrefixTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem ヘルプhToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
		private System.Windows.Forms.TextBox keywordSampleTextBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.NumericUpDown timeLeftNumericUpDown;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label aliveLabel;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox weatherSampleTextBox;
		private System.Windows.Forms.ComboBox weatherMiddleComboBox;
		private System.Windows.Forms.ToolStripMenuItem おまけOToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 左上付き運営コメントToolStripMenuItem;
		private System.Windows.Forms.TextBox keywordNotFoundTextBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox weatherNotCityTextBox;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox weatherNotDayTextBox;
		private System.Windows.Forms.TextBox successSuffixTextBox;
		private System.Windows.Forms.Label label18;
	}
}

