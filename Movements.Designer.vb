<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Movements
    Inherits System.Windows.Forms.Form

    'Formularz przesłania metodę dispose, aby wyczyścić listę składników.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'UWAGA: następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Możesz to modyfikować, używając Projektanta formularzy systemu Windows. 
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.butStartMove = New System.Windows.Forms.Button()
        Me.spAx_X = New System.IO.Ports.SerialPort(Me.components)
        Me.spAx_Y = New System.IO.Ports.SerialPort(Me.components)
        Me.spAx_Fi = New System.IO.Ports.SerialPort(Me.components)
        Me.butPrepare = New System.Windows.Forms.Button()
        Me.butInking = New System.Windows.Forms.Button()
        Me.grbMoveTo = New System.Windows.Forms.GroupBox()
        Me.numFi = New System.Windows.Forms.NumericUpDown()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        Me.numX = New System.Windows.Forms.NumericUpDown()
        Me.lblMoveFi = New System.Windows.Forms.Label()
        Me.lblMoveY = New System.Windows.Forms.Label()
        Me.lblMoveX = New System.Windows.Forms.Label()
        Me.grbPosition = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbMoveTo.SuspendLayout()
        CType(Me.numFi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbPosition.SuspendLayout()
        Me.SuspendLayout()
        '
        'butStartMove
        '
        Me.butStartMove.Location = New System.Drawing.Point(350, 111)
        Me.butStartMove.Margin = New System.Windows.Forms.Padding(2)
        Me.butStartMove.Name = "butStartMove"
        Me.butStartMove.Size = New System.Drawing.Size(154, 41)
        Me.butStartMove.TabIndex = 0
        Me.butStartMove.Text = "Start Move"
        Me.butStartMove.UseVisualStyleBackColor = True
        '
        'spAx_X
        '
        '
        'spAx_Y
        '
        '
        'spAx_Fi
        '
        '
        'butPrepare
        '
        Me.butPrepare.Location = New System.Drawing.Point(350, 36)
        Me.butPrepare.Margin = New System.Windows.Forms.Padding(2)
        Me.butPrepare.Name = "butPrepare"
        Me.butPrepare.Size = New System.Drawing.Size(154, 41)
        Me.butPrepare.TabIndex = 7
        Me.butPrepare.Text = "Prepare"
        Me.butPrepare.UseVisualStyleBackColor = True
        '
        'butInking
        '
        Me.butInking.Location = New System.Drawing.Point(350, 185)
        Me.butInking.Margin = New System.Windows.Forms.Padding(2)
        Me.butInking.Name = "butInking"
        Me.butInking.Size = New System.Drawing.Size(154, 41)
        Me.butInking.TabIndex = 8
        Me.butInking.Text = "Make Inking"
        Me.butInking.UseVisualStyleBackColor = True
        '
        'grbMoveTo
        '
        Me.grbMoveTo.Controls.Add(Me.numFi)
        Me.grbMoveTo.Controls.Add(Me.numY)
        Me.grbMoveTo.Controls.Add(Me.numX)
        Me.grbMoveTo.Controls.Add(Me.lblMoveFi)
        Me.grbMoveTo.Controls.Add(Me.lblMoveY)
        Me.grbMoveTo.Controls.Add(Me.lblMoveX)
        Me.grbMoveTo.Location = New System.Drawing.Point(12, 12)
        Me.grbMoveTo.Name = "grbMoveTo"
        Me.grbMoveTo.Size = New System.Drawing.Size(120, 220)
        Me.grbMoveTo.TabIndex = 9
        Me.grbMoveTo.TabStop = False
        Me.grbMoveTo.Text = "Move to ..."
        '
        'numFi
        '
        Me.numFi.DecimalPlaces = 1
        Me.numFi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numFi.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numFi.Location = New System.Drawing.Point(15, 180)
        Me.numFi.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.numFi.Name = "numFi"
        Me.numFi.Size = New System.Drawing.Size(90, 26)
        Me.numFi.TabIndex = 12
        Me.numFi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numY
        '
        Me.numY.DecimalPlaces = 1
        Me.numY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numY.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numY.Location = New System.Drawing.Point(15, 106)
        Me.numY.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(90, 26)
        Me.numY.TabIndex = 11
        Me.numY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numX
        '
        Me.numX.DecimalPlaces = 1
        Me.numX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numX.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.numX.Location = New System.Drawing.Point(15, 31)
        Me.numX.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.numX.Name = "numX"
        Me.numX.Size = New System.Drawing.Size(90, 26)
        Me.numX.TabIndex = 10
        Me.numX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMoveFi
        '
        Me.lblMoveFi.AutoSize = True
        Me.lblMoveFi.Location = New System.Drawing.Point(12, 164)
        Me.lblMoveFi.Name = "lblMoveFi"
        Me.lblMoveFi.Size = New System.Drawing.Size(42, 13)
        Me.lblMoveFi.TabIndex = 9
        Me.lblMoveFi.Text = "Fi [deg]"
        '
        'lblMoveY
        '
        Me.lblMoveY.AutoSize = True
        Me.lblMoveY.Location = New System.Drawing.Point(12, 90)
        Me.lblMoveY.Name = "lblMoveY"
        Me.lblMoveY.Size = New System.Drawing.Size(39, 13)
        Me.lblMoveY.TabIndex = 8
        Me.lblMoveY.Text = "Y [mm]"
        '
        'lblMoveX
        '
        Me.lblMoveX.AutoSize = True
        Me.lblMoveX.Location = New System.Drawing.Point(12, 15)
        Me.lblMoveX.Name = "lblMoveX"
        Me.lblMoveX.Size = New System.Drawing.Size(39, 13)
        Me.lblMoveX.TabIndex = 7
        Me.lblMoveX.Text = "X [mm]"
        '
        'grbPosition
        '
        Me.grbPosition.Controls.Add(Me.TextBox3)
        Me.grbPosition.Controls.Add(Me.TextBox2)
        Me.grbPosition.Controls.Add(Me.TextBox1)
        Me.grbPosition.Controls.Add(Me.Label3)
        Me.grbPosition.Controls.Add(Me.Label2)
        Me.grbPosition.Controls.Add(Me.Label1)
        Me.grbPosition.Location = New System.Drawing.Point(181, 12)
        Me.grbPosition.Name = "grbPosition"
        Me.grbPosition.Size = New System.Drawing.Size(100, 219)
        Me.grbPosition.TabIndex = 10
        Me.grbPosition.TabStop = False
        Me.grbPosition.Text = "Position"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(9, 179)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(74, 26)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(9, 105)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(74, 26)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(9, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(74, 26)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Movements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.grbPosition)
        Me.Controls.Add(Me.grbMoveTo)
        Me.Controls.Add(Me.butInking)
        Me.Controls.Add(Me.butPrepare)
        Me.Controls.Add(Me.butStartMove)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Movements"
        Me.Text = "Form1"
        Me.grbMoveTo.ResumeLayout(False)
        Me.grbMoveTo.PerformLayout()
        CType(Me.numFi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbPosition.ResumeLayout(False)
        Me.grbPosition.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents butStartMove As Button
    Friend WithEvents spAx_X As IO.Ports.SerialPort
    Friend WithEvents spAx_Y As IO.Ports.SerialPort
    Private components As System.ComponentModel.IContainer
    Friend WithEvents spAx_Fi As IO.Ports.SerialPort
    Friend WithEvents butPrepare As Button
    Friend WithEvents butInking As Button
    Friend WithEvents grbMoveTo As GroupBox
    Friend WithEvents numFi As NumericUpDown
    Friend WithEvents numY As NumericUpDown
    Friend WithEvents numX As NumericUpDown
    Friend WithEvents lblMoveFi As Label
    Friend WithEvents lblMoveY As Label
    Friend WithEvents lblMoveX As Label
    Friend WithEvents grbPosition As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
