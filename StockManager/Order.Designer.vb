<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Order
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.splitContainer = New System.Windows.Forms.SplitContainer()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.panelProductActions = New System.Windows.Forms.Panel()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.panelCartActions = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panelHeader.SuspendLayout()
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer.Panel1.SuspendLayout()
        Me.splitContainer.Panel2.SuspendLayout()
        Me.splitContainer.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelProductActions.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelCartActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1067, 60)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(12, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(273, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Nouvelle Commande"
        '
        'splitContainer
        '
        Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer.Location = New System.Drawing.Point(0, 60)
        Me.splitContainer.Name = "splitContainer"
        '
        'splitContainer.Panel1
        '
        Me.splitContainer.Panel1.Controls.Add(Me.dgvProducts)
        Me.splitContainer.Panel1.Controls.Add(Me.panelProductActions)
        Me.splitContainer.Panel1.Padding = New System.Windows.Forms.Padding(10)
        '
        'splitContainer.Panel2
        '
        Me.splitContainer.Panel2.Controls.Add(Me.dgvCart)
        Me.splitContainer.Panel2.Controls.Add(Me.panelCartActions)
        Me.splitContainer.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.splitContainer.Size = New System.Drawing.Size(1067, 512)
        Me.splitContainer.SplitterDistance = 533
        Me.splitContainer.TabIndex = 1
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProducts.Location = New System.Drawing.Point(10, 10)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.RowHeadersWidth = 51
        Me.dgvProducts.RowTemplate.Height = 24
        Me.dgvProducts.Size = New System.Drawing.Size(513, 442)
        Me.dgvProducts.TabIndex = 1
        '
        'panelProductActions
        '
        Me.panelProductActions.Controls.Add(Me.lblQty)
        Me.panelProductActions.Controls.Add(Me.numQuantity)
        Me.panelProductActions.Controls.Add(Me.btnAddToCart)
        Me.panelProductActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelProductActions.Location = New System.Drawing.Point(10, 452)
        Me.panelProductActions.Name = "panelProductActions"
        Me.panelProductActions.Size = New System.Drawing.Size(513, 50)
        Me.panelProductActions.TabIndex = 0
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(3, 17)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(33, 17)
        Me.lblQty.TabIndex = 2
        Me.lblQty.Text = "Qté:"
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(42, 15)
        Me.numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(80, 22)
        Me.numQuantity.TabIndex = 1
        Me.numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnAddToCart
        '
        Me.btnAddToCart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddToCart.Location = New System.Drawing.Point(363, 8)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(147, 35)
        Me.btnAddToCart.TabIndex = 0
        Me.btnAddToCart.Text = "Ajouter >>"
        Me.btnAddToCart.UseVisualStyleBackColor = True
        '
        'dgvCart
        '
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCart.Location = New System.Drawing.Point(10, 10)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.RowHeadersWidth = 51
        Me.dgvCart.RowTemplate.Height = 24
        Me.dgvCart.Size = New System.Drawing.Size(510, 392)
        Me.dgvCart.TabIndex = 1
        '
        'panelCartActions
        '
        Me.panelCartActions.Controls.Add(Me.lblTotal)
        Me.panelCartActions.Controls.Add(Me.btnRemoveItem)
        Me.panelCartActions.Controls.Add(Me.btnValidate)
        Me.panelCartActions.Controls.Add(Me.btnCancel)
        Me.panelCartActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelCartActions.Location = New System.Drawing.Point(10, 402)
        Me.panelCartActions.Name = "panelCartActions"
        Me.panelCartActions.Size = New System.Drawing.Size(510, 100)
        Me.panelCartActions.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.Location = New System.Drawing.Point(3, 10)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(117, 28)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total: 0 DH"
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveItem.Location = New System.Drawing.Point(379, 10)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(128, 30)
        Me.btnRemoveItem.TabIndex = 2
        Me.btnRemoveItem.Text = "Retirer Item"
        Me.btnRemoveItem.UseVisualStyleBackColor = True
        '
        'btnValidate
        '
        Me.btnValidate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidate.Location = New System.Drawing.Point(232, 54)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(130, 40)
        Me.btnValidate.TabIndex = 1
        Me.btnValidate.Text = "Valider"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(377, 54)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 40)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Annuler"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 572)
        Me.Controls.Add(Me.splitContainer)
        Me.Controls.Add(Me.panelHeader)
        Me.Name = "Order"
        Me.Text = "Gestion des Commandes"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.splitContainer.Panel1.ResumeLayout(False)
        Me.splitContainer.Panel2.ResumeLayout(False)
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer.ResumeLayout(False)
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelProductActions.ResumeLayout(False)
        Me.panelProductActions.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelCartActions.ResumeLayout(False)
        Me.panelCartActions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents splitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents panelProductActions As System.Windows.Forms.Panel
    Friend WithEvents dgvCart As System.Windows.Forms.DataGridView
    Friend WithEvents panelCartActions As System.Windows.Forms.Panel
    Friend WithEvents btnAddToCart As System.Windows.Forms.Button
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRemoveItem As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
End Class
