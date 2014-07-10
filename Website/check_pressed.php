<?php
session_start();
if(!($_SESSION["loggedIn"]==true)) // if there is no valid session
{
    header("Location: index.php");
}

if(isset($_POST['mail'])) 
{
header("Location: mail.php");
}

else if(isset($_POST['cancel'])) 
{
	header("Location: index.php");
}

else if(isset($_POST['submit']))
{
$link = mysql_connect("sql2.freesqldatabase.com","sql237801","xI7!wD3!");
mysql_select_db("sql237801", $link);
mysql_query("SET character_set_clint=utf8");
mysql_query("SET character_set_connection=utf8");
mysql_query("SET character_set_database=utf8");
mysql_query("SET character_set_results=utf8");
mysql_query("SET character_set_server=utf8");
mysql_query("SET NAMES utf8"); 

$temp=$_POST['rowCounter'];
for ($i=0;$i<$temp;$i++) 
{
    $name = $_POST['names'][$i];
    $appartment = $_POST['appartment_numbers'][$i];
	$jan=$_POST['jan14'][$i];
	$feb=$_POST['feb14'][$i];
	$mar=$_POST['mar14'][$i];
	$apr=$_POST['apr14'][$i];
	$may=$_POST['may14'][$i];
	$jun=$_POST['jun14'][$i];
	$jul=$_POST['jul14'][$i];
	$aug=$_POST['aug14'][$i];
	$sep=$_POST['sep14'][$i];
	$oct=$_POST['oct14'][$i];
	$nov=$_POST['nov14'][$i];
	$dec=$_POST['dec14'][$i];

	$sql="UPDATE tenants SET january14 ='".$jan."',february14='".$feb."',march14='".$mar."', april14='".$apr."', may14='".$may."', june14='".$jun."', july14='".$jul."', august14='".$aug."',september14='".$sep."',october14='".$oct."',november14='".$nov."',december14='".$dec."' WHERE name='".$name."'";
	mysql_query($sql, $link);

			
}
header("Location: table.php");
}
?>