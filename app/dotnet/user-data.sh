#!/bin/bash
sudo su
rpm --import https://packages.microsoft.com/keys/microsoft.asc
echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl= https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/dotnetdev.repo
yum update -y
yum install libunwind libicu -y
yum install dotnet-sdk-2.1.4 -y
chmod +x /etc/rc.d/rc.local

echo '#!/bin/bash
mkdir /app
cd /app && rm * -rf
wget https://s3.amazonaws.com/apptical-test/NotesApp.zip 
unzip -qqo NotesApp.zip -d ./ || :
export NUGET_PACKAGES="/home/ec2-user/.nuget"
sudo dotnet restore
sudo dotnet run  -- --`curl http://169.254.169.254/latest/meta-data/local-ipv4` ip &
' > /home/ec2-user/notesapp.sh
chmod 755 /home/ec2-user/notesapp.sh
echo '/home/ec2-user/notesapp.sh' >> /etc/rc.d/rc.local
/home/ec2-user/notesapp.sh 
#cat /var/log/cloud-init-output.log