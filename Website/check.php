<?php
session_start();




$link = mysql_connect("sql2.freesqldatabase.com","sql237801","xI7!wD3!");
mysql_select_db("sql237801", $link);

$user =$_POST['username'];
$pass =$_POST['password'];
$result = mysql_query("SELECT * FROM users WHERE id='$user' AND pass='$pass'",$link);

$num_rows = mysql_num_rows($result);

	
		
		if($num_rows>0)
		{		
		$_SESSION["loggedIn"] = true; 
		header("Location: table.php");
			
		}	
		else{
			header("Location: index.php");
		}


?>