namespace WindowsFormsApp1
{
    partial class OrderViewForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderViewForm));
            System.Windows.Forms.Label booknameLabel;
            System.Windows.Forms.Label b_authorLabel;
            System.Windows.Forms.Label b_priceLabel;
            System.Windows.Forms.Label cat_nameLabel;
            System.Windows.Forms.Label b_yearLabel;
            System.Windows.Forms.Label order_IDLabel;
            System.Windows.Forms.Label o_timeLabel;
            System.Windows.Forms.Label o_numberLabel;
            System.Windows.Forms.Label userssurnameLabel;
            System.Windows.Forms.Label u_phoneLabel;
            System.Windows.Forms.Label u_emailLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.bookshopDataSet = new WindowsFormsApp1.bookshopDataSet();
            this.view_orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_orderTableAdapter = new WindowsFormsApp1.bookshopDataSetTableAdapters.view_orderTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.bookshopDataSetTableAdapters.TableAdapterManager();
            this.view_orderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.view_orderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.booknameTextBox = new System.Windows.Forms.TextBox();
            this.b_authorTextBox = new System.Windows.Forms.TextBox();
            this.b_priceTextBox = new System.Windows.Forms.TextBox();
            this.cat_nameTextBox = new System.Windows.Forms.TextBox();
            this.b_yearTextBox = new System.Windows.Forms.TextBox();
            this.order_IDTextBox = new System.Windows.Forms.TextBox();
            this.o_timeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.o_numberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userssurnameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.userpatronymicTextBox = new System.Windows.Forms.TextBox();
            this.u_phoneTextBox = new System.Windows.Forms.TextBox();
            this.u_emailTextBox = new System.Windows.Forms.TextBox();
            this.textBoxCalculate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            booknameLabel = new System.Windows.Forms.Label();
            b_authorLabel = new System.Windows.Forms.Label();
            b_priceLabel = new System.Windows.Forms.Label();
            cat_nameLabel = new System.Windows.Forms.Label();
            b_yearLabel = new System.Windows.Forms.Label();
            order_IDLabel = new System.Windows.Forms.Label();
            o_timeLabel = new System.Windows.Forms.Label();
            o_numberLabel = new System.Windows.Forms.Label();
            userssurnameLabel = new System.Windows.Forms.Label();
            u_phoneLabel = new System.Windows.Forms.Label();
            u_emailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bookshopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_orderBindingNavigator)).BeginInit();
            this.view_orderBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(353, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заказы";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bookshopDataSet
            // 
            this.bookshopDataSet.DataSetName = "bookshopDataSet";
            this.bookshopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_orderBindingSource
            // 
            this.view_orderBindingSource.DataMember = "view_order";
            this.view_orderBindingSource.DataSource = this.bookshopDataSet;
            // 
            // view_orderTableAdapter
            // 
            this.view_orderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.booksTableAdapter = null;
            this.tableAdapterManager.catalogsTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.februaryTableAdapter = null;
            this.tableAdapterManager.ordersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1.bookshopDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            // 
            // view_orderBindingNavigator
            // 
            this.view_orderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.view_orderBindingNavigator.BindingSource = this.view_orderBindingSource;
            this.view_orderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.view_orderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.view_orderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.view_orderBindingNavigatorSaveItem});
            this.view_orderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.view_orderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.view_orderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.view_orderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.view_orderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.view_orderBindingNavigator.Name = "view_orderBindingNavigator";
            this.view_orderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.view_orderBindingNavigator.Size = new System.Drawing.Size(811, 25);
            this.view_orderBindingNavigator.TabIndex = 1;
            this.view_orderBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // view_orderBindingNavigatorSaveItem
            // 
            this.view_orderBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.view_orderBindingNavigatorSaveItem.Enabled = false;
            this.view_orderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("view_orderBindingNavigatorSaveItem.Image")));
            this.view_orderBindingNavigatorSaveItem.Name = "view_orderBindingNavigatorSaveItem";
            this.view_orderBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.view_orderBindingNavigatorSaveItem.Text = "Сохранить данные";
            // 
            // booknameLabel
            // 
            booknameLabel.AutoSize = true;
            booknameLabel.Location = new System.Drawing.Point(102, 74);
            booknameLabel.Name = "booknameLabel";
            booknameLabel.Size = new System.Drawing.Size(57, 13);
            booknameLabel.TabIndex = 2;
            booknameLabel.Text = "Название";
            // 
            // booknameTextBox
            // 
            this.booknameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "bookname", true));
            this.booknameTextBox.Location = new System.Drawing.Point(168, 71);
            this.booknameTextBox.Name = "booknameTextBox";
            this.booknameTextBox.Size = new System.Drawing.Size(579, 20);
            this.booknameTextBox.TabIndex = 3;
            // 
            // b_authorLabel
            // 
            b_authorLabel.AutoSize = true;
            b_authorLabel.Location = new System.Drawing.Point(113, 100);
            b_authorLabel.Name = "b_authorLabel";
            b_authorLabel.Size = new System.Drawing.Size(37, 13);
            b_authorLabel.TabIndex = 4;
            b_authorLabel.Text = "Автор";
            // 
            // b_authorTextBox
            // 
            this.b_authorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "b_author", true));
            this.b_authorTextBox.Location = new System.Drawing.Point(168, 97);
            this.b_authorTextBox.Name = "b_authorTextBox";
            this.b_authorTextBox.Size = new System.Drawing.Size(364, 20);
            this.b_authorTextBox.TabIndex = 5;
            // 
            // b_priceLabel
            // 
            b_priceLabel.AutoSize = true;
            b_priceLabel.Location = new System.Drawing.Point(120, 126);
            b_priceLabel.Name = "b_priceLabel";
            b_priceLabel.Size = new System.Drawing.Size(33, 13);
            b_priceLabel.TabIndex = 6;
            b_priceLabel.Text = "Цена";
            // 
            // b_priceTextBox
            // 
            this.b_priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "b_price", true));
            this.b_priceTextBox.Location = new System.Drawing.Point(168, 123);
            this.b_priceTextBox.Name = "b_priceTextBox";
            this.b_priceTextBox.Size = new System.Drawing.Size(100, 20);
            this.b_priceTextBox.TabIndex = 7;
            this.b_priceTextBox.TextChanged += new System.EventHandler(this.b_priceTextBox_TextChanged);
            // 
            // cat_nameLabel
            // 
            cat_nameLabel.AutoSize = true;
            cat_nameLabel.Location = new System.Drawing.Point(274, 126);
            cat_nameLabel.Name = "cat_nameLabel";
            cat_nameLabel.Size = new System.Drawing.Size(106, 13);
            cat_nameLabel.TabIndex = 8;
            cat_nameLabel.Text = "Название каталога";
            // 
            // cat_nameTextBox
            // 
            this.cat_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "cat_name", true));
            this.cat_nameTextBox.Location = new System.Drawing.Point(386, 123);
            this.cat_nameTextBox.Name = "cat_nameTextBox";
            this.cat_nameTextBox.Size = new System.Drawing.Size(361, 20);
            this.cat_nameTextBox.TabIndex = 9;
            // 
            // b_yearLabel
            // 
            b_yearLabel.AutoSize = true;
            b_yearLabel.Location = new System.Drawing.Point(541, 100);
            b_yearLabel.Name = "b_yearLabel";
            b_yearLabel.Size = new System.Drawing.Size(70, 13);
            b_yearLabel.TabIndex = 10;
            b_yearLabel.Text = "Год издания";
            // 
            // b_yearTextBox
            // 
            this.b_yearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "b_year", true));
            this.b_yearTextBox.Location = new System.Drawing.Point(617, 97);
            this.b_yearTextBox.Name = "b_yearTextBox";
            this.b_yearTextBox.Size = new System.Drawing.Size(130, 20);
            this.b_yearTextBox.TabIndex = 11;
            // 
            // order_IDLabel
            // 
            order_IDLabel.AutoSize = true;
            order_IDLabel.Location = new System.Drawing.Point(82, 210);
            order_IDLabel.Name = "order_IDLabel";
            order_IDLabel.Size = new System.Drawing.Size(80, 13);
            order_IDLabel.TabIndex = 12;
            order_IDLabel.Text = "Номер заказа";
            // 
            // order_IDTextBox
            // 
            this.order_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "order_ID", true));
            this.order_IDTextBox.Location = new System.Drawing.Point(168, 207);
            this.order_IDTextBox.Name = "order_IDTextBox";
            this.order_IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.order_IDTextBox.TabIndex = 13;
            // 
            // o_timeLabel
            // 
            o_timeLabel.AutoSize = true;
            o_timeLabel.Location = new System.Drawing.Point(274, 210);
            o_timeLabel.Name = "o_timeLabel";
            o_timeLabel.Size = new System.Drawing.Size(72, 13);
            o_timeLabel.TabIndex = 14;
            o_timeLabel.Text = "Дата заказа";
            o_timeLabel.Click += new System.EventHandler(this.o_timeLabel_Click);
            // 
            // o_timeDateTimePicker
            // 
            this.o_timeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.view_orderBindingSource, "o_time", true));
            this.o_timeDateTimePicker.Location = new System.Drawing.Point(352, 207);
            this.o_timeDateTimePicker.Name = "o_timeDateTimePicker";
            this.o_timeDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.o_timeDateTimePicker.TabIndex = 15;
            this.o_timeDateTimePicker.ValueChanged += new System.EventHandler(this.o_timeDateTimePicker_ValueChanged);
            // 
            // o_numberLabel
            // 
            o_numberLabel.AutoSize = true;
            o_numberLabel.Location = new System.Drawing.Point(498, 210);
            o_numberLabel.Name = "o_numberLabel";
            o_numberLabel.Size = new System.Drawing.Size(111, 13);
            o_numberLabel.TabIndex = 16;
            o_numberLabel.Text = "Количество позиций";
            // 
            // o_numberTextBox
            // 
            this.o_numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "o_number", true));
            this.o_numberTextBox.Location = new System.Drawing.Point(615, 207);
            this.o_numberTextBox.Name = "o_numberTextBox";
            this.o_numberTextBox.Size = new System.Drawing.Size(132, 20);
            this.o_numberTextBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Данные покупателя";
            // 
            // userssurnameLabel
            // 
            userssurnameLabel.AutoSize = true;
            userssurnameLabel.Location = new System.Drawing.Point(104, 318);
            userssurnameLabel.Name = "userssurnameLabel";
            userssurnameLabel.Size = new System.Drawing.Size(34, 13);
            userssurnameLabel.TabIndex = 19;
            userssurnameLabel.Text = "ФИО";
            // 
            // userssurnameTextBox
            // 
            this.userssurnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "userssurname", true));
            this.userssurnameTextBox.Location = new System.Drawing.Point(154, 315);
            this.userssurnameTextBox.Name = "userssurnameTextBox";
            this.userssurnameTextBox.Size = new System.Drawing.Size(282, 20);
            this.userssurnameTextBox.TabIndex = 20;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(442, 315);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(136, 20);
            this.usernameTextBox.TabIndex = 22;
            // 
            // userpatronymicTextBox
            // 
            this.userpatronymicTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "userpatronymic", true));
            this.userpatronymicTextBox.Location = new System.Drawing.Point(584, 315);
            this.userpatronymicTextBox.Name = "userpatronymicTextBox";
            this.userpatronymicTextBox.Size = new System.Drawing.Size(163, 20);
            this.userpatronymicTextBox.TabIndex = 24;
            // 
            // u_phoneLabel
            // 
            u_phoneLabel.AutoSize = true;
            u_phoneLabel.Location = new System.Drawing.Point(96, 344);
            u_phoneLabel.Name = "u_phoneLabel";
            u_phoneLabel.Size = new System.Drawing.Size(52, 13);
            u_phoneLabel.TabIndex = 25;
            u_phoneLabel.Text = "Телефон";
            // 
            // u_phoneTextBox
            // 
            this.u_phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "u_phone", true));
            this.u_phoneTextBox.Location = new System.Drawing.Point(154, 341);
            this.u_phoneTextBox.Name = "u_phoneTextBox";
            this.u_phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.u_phoneTextBox.TabIndex = 26;
            // 
            // u_emailLabel
            // 
            u_emailLabel.AutoSize = true;
            u_emailLabel.Location = new System.Drawing.Point(293, 344);
            u_emailLabel.Name = "u_emailLabel";
            u_emailLabel.Size = new System.Drawing.Size(37, 13);
            u_emailLabel.TabIndex = 27;
            u_emailLabel.Text = "Почта";
            // 
            // u_emailTextBox
            // 
            this.u_emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.view_orderBindingSource, "u_email", true));
            this.u_emailTextBox.Location = new System.Drawing.Point(336, 341);
            this.u_emailTextBox.Name = "u_emailTextBox";
            this.u_emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.u_emailTextBox.TabIndex = 28;
            // 
            // textBoxCalculate
            // 
            this.textBoxCalculate.Location = new System.Drawing.Point(544, 390);
            this.textBoxCalculate.Name = "textBoxCalculate";
            this.textBoxCalculate.Size = new System.Drawing.Size(100, 20);
            this.textBoxCalculate.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(458, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Сумма заказа";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCalculate);
            this.Controls.Add(u_emailLabel);
            this.Controls.Add(this.u_emailTextBox);
            this.Controls.Add(u_phoneLabel);
            this.Controls.Add(this.u_phoneTextBox);
            this.Controls.Add(this.userpatronymicTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(userssurnameLabel);
            this.Controls.Add(this.userssurnameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(o_numberLabel);
            this.Controls.Add(this.o_numberTextBox);
            this.Controls.Add(o_timeLabel);
            this.Controls.Add(this.o_timeDateTimePicker);
            this.Controls.Add(order_IDLabel);
            this.Controls.Add(this.order_IDTextBox);
            this.Controls.Add(b_yearLabel);
            this.Controls.Add(this.b_yearTextBox);
            this.Controls.Add(cat_nameLabel);
            this.Controls.Add(this.cat_nameTextBox);
            this.Controls.Add(b_priceLabel);
            this.Controls.Add(this.b_priceTextBox);
            this.Controls.Add(b_authorLabel);
            this.Controls.Add(this.b_authorTextBox);
            this.Controls.Add(booknameLabel);
            this.Controls.Add(this.booknameTextBox);
            this.Controls.Add(this.view_orderBindingNavigator);
            this.Controls.Add(this.label1);
            this.Name = "OrderViewForm";
            this.Text = "OrderViewForm";
            this.Load += new System.EventHandler(this.OrderViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookshopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_orderBindingNavigator)).EndInit();
            this.view_orderBindingNavigator.ResumeLayout(false);
            this.view_orderBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private bookshopDataSet bookshopDataSet;
        private System.Windows.Forms.BindingSource view_orderBindingSource;
        private bookshopDataSetTableAdapters.view_orderTableAdapter view_orderTableAdapter;
        private bookshopDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator view_orderBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton view_orderBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox booknameTextBox;
        private System.Windows.Forms.TextBox b_authorTextBox;
        private System.Windows.Forms.TextBox b_priceTextBox;
        private System.Windows.Forms.TextBox cat_nameTextBox;
        private System.Windows.Forms.TextBox b_yearTextBox;
        private System.Windows.Forms.TextBox order_IDTextBox;
        private System.Windows.Forms.DateTimePicker o_timeDateTimePicker;
        private System.Windows.Forms.TextBox o_numberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userssurnameTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox userpatronymicTextBox;
        private System.Windows.Forms.TextBox u_phoneTextBox;
        private System.Windows.Forms.TextBox u_emailTextBox;
        private System.Windows.Forms.TextBox textBoxCalculate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}