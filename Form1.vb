Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menambahkan pilihan ke ComboBox Fakultas
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("MIPA")
        ComboBox1.Items.Add("HUKUM")
        ComboBox1.Items.Add("FISIP")
        ComboBox1.Items.Add("TEKNIK")
        ComboBox1.Items.Add("FEB")
        ComboBox1.Items.Add("KEDOKTERAN")

        ' Menambahkan pilihan ke ComboBox Jurusan
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("ILMU KOMPUTER")
        ComboBox2.Items.Add("MANAJEMEN INFORMATIKA")

        ' Mengatur default pilihan kosong
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        ' Validasi apakah input kosong
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Semua data harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validasi jenis kelamin
        Dim jenisKelamin As String = ""
        If RadioButton1.Checked Then
            jenisKelamin = "Laki - Laki"
        ElseIf RadioButton2.Checked Then
            jenisKelamin = "Perempuan"
        Else
            MessageBox.Show("Silakan pilih jenis kelamin!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Ambil nilai dari input
        Dim nip As String = TextBox1.Text
        Dim nama As String = TextBox2.Text
        Dim fakultas As String = ComboBox1.Text
        Dim jurusan As String = ComboBox2.Text

        ' Validasi input nilai tugas, UTS, dan UAS
        Dim tugas, uts, uas As Double

        If Not Double.TryParse(TextBoxTugas.Text, tugas) Or tugas < 0 Or tugas > 100 Then
            MessageBox.Show("Nilai Tugas harus antara 0 - 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Double.TryParse(TextBoxUTS.Text, uts) Or uts < 0 Or uts > 100 Then
            MessageBox.Show("Nilai UTS harus antara 0 - 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Double.TryParse(TextBoxUAS.Text, uas) Or uas < 0 Or uas > 100 Then
            MessageBox.Show("Nilai UAS harus antara 0 - 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Menghitung nilai akhir berdasarkan bobot
        Dim nilaiAkhir As Double = (tugas * 0.3) + (uts * 0.3) + (uas * 0.4)

        ' Menentukan GRADE berdasarkan nilai akhir
        Dim grade As String

        If nilaiAkhir >= 85 Then
            grade = "A"
        ElseIf nilaiAkhir >= 75 Then
            grade = "B"
        ElseIf nilaiAkhir >= 60 Then
            grade = "C"
        ElseIf nilaiAkhir >= 40 Then
            grade = "D"
        Else
            grade = "E"
        End If

        ' Menampilkan hasil dalam MessageBox
        Dim hasil As String = "NIP : " & nip & vbCrLf &
                              "Nama : " & nama & vbCrLf &
                              "Jenis Kelamin : " & jenisKelamin & vbCrLf &
                              "Fakultas : " & fakultas & vbCrLf &
                              "Jurusan : " & jurusan & vbCrLf &
                              "Nilai Tugas : " & tugas & vbCrLf &
                              "Nilai UTS : " & uts & vbCrLf &
                              "Nilai UAS : " & uas & vbCrLf &
                              "Nilai Akhir : " & nilaiAkhir & vbCrLf &
                              "GRADE : " & grade

        MessageBox.Show(hasil, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
