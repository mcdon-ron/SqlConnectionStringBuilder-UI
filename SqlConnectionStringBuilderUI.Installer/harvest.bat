@pushd "%~dp0"
"%wix%bin\heat.exe" dir "..\SqlConnectionStringBuilderUI\bin\Release\net8.0-windows7.0" -ag -cg ProductComponents -dr INSTALLFOLDER -out ProductComponents.wxs -scom -sfrag -srd -sreg -suid -svb6 -var var.SqlConnectionStringBuilderUI.TargetDir
@popd
