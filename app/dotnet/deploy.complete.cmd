del NotesApp.zip
cd NotesApp.Complete\NotesApp.Complete
powershell.exe -nologo -noprofile -command "& { Add-Type -A 'System.IO.Compression.FileSystem'; [IO.Compression.ZipFile]::CreateFromDirectory('.\', '../NotesApp.zip') }"
aws s3 cp ../NotesApp.zip s3://apptical-test/ --acl public-read
