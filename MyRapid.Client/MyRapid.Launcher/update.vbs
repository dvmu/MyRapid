'��ʱ�ȴ�
On Error Resume Next

'ѭ��3�� 3��
For i = 0 To 3  Step 1

FileReplace "MyRapid.Client.exe.txt" ,"MyRapid.Client.exe.config"
FileReplace "MyRapid.Launcher2.exe" ,"MyRapid.Launcher.exe"
'��ʱ1��
WScript.Sleep 1000
Next

'
Function FileDelete(delFile)
  Set oFSO = CreateObject("Scripting.FileSystemObject") 
  If oFSO.FileExists(delFile) Then 
      oFSO.DeleteFile(delFile)
  End If
  If oFSO.FolderExists(delFile) Then
      oFSO.DeleteFolder delFile,True
  End If
End Function

Function FileReplace(oldFile ,NewFile)
  Set oFSO = CreateObject("Scripting.FileSystemObject") 
  If oFSO.FileExists(oldFile) Then 
    If oFSO.FileExists(NewFile) Then
      oFSO.DeleteFile(NewFile)
    End If
    Set File = oFSO.GetFile(oldFile)
    '�������ļ�
    File.name= NewFile
  End If
End Function

Function FileLink(linkFile ,linkName) 
  SET oFSO = CreateObject("Scripting.FileSystemObject")
  If oFSO.FileExists(linkFile) Then 
    Set linkDir = oFSO.GetFile(Wscript.ScriptName).ParentFolder
    Set WshShell = WScript.CreateObject("WScript.Shell")
    strDesktop = WshShell.SpecialFolders("Desktop") '�����ļ��С����桱
    '�����洴��һ����ݷ�ʽ
    set oShellLink = WshShell.CreateShortcut(strDesktop & "\" & linkName & ".lnk")
    oShellLink.TargetPath = linkDir & "\" & linkFile  '��ִ���ļ�·��
    oShellLink.Arguments = "" '����Ĳ���
    oShellLink.WindowStyle = 1 '����1Ĭ�ϴ��ڼ������3��󻯼������7��С��
    oShellLink.Hotkey = ""  '��ݼ�
    oShellLink.IconLocation = linkDir & "\" & linkFile & ", 0"  'ͼ��
    oShellLink.Description = ""  '��ע
    oShellLink.WorkingDirectory = linkDir  '��ʼλ��
    oShellLink.Save  '���������ݷ�ʽ
  End If
End Function

'ɾ���Լ�
SET oFSO = CreateObject("Scripting.FileSystemObject")
oFSO.DeleteFile(WScript.ScriptName)

