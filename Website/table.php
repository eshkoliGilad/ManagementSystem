<?php
session_start();
if(!($_SESSION["loggedIn"]==true)) // if there is no valid session
{
    header("Location: index.php");
}
?>
<!DOCTYPE html>
<html>
<?php 

$_SESSION["building_session"];
//NEEDS TO MAKE GLOBAL OR SESSION FOR TABLE UPDATED WHEN SAVING !!!

if(isset($_POST['buildings_name'])) 
{
$choice=$_POST['buildings_name'];
$_SESSION["building_session"]=$choice;
}
else
{
$choice=$_SESSION["building_session"];
}

$rowCounter=0;

$link = mysql_connect("sql2.freesqldatabase.com","sql237801","xI7!wD3!");
mysql_select_db("sql237801", $link);
mysql_query("SET character_set_clint=utf8");
mysql_query("SET character_set_connection=utf8");
mysql_query("SET character_set_database=utf8");
mysql_query("SET character_set_results=utf8");
mysql_query("SET character_set_server=utf8");
mysql_query("SET NAMES utf8");
?>
<head>
	<meta charset='UTF-8'>
	<meta name="apple-mobile-web-app-status-bar-style" content="white-translucent"/>
	<title>אתר גביות - א.ש.אחזקות</title>
	
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="format-detection" content="telephone=no" />
	<link rel="stylesheet" href="style_table.css">
	
	<!--[if !IE]><!-->
	<style>
	
	/* 
	Max width before this PARTICULAR table gets nasty
	This query will take effect for any screen smaller than 760px
	and also iPads specifically.
	*/
	@media 
	only screen and (max-width: 760px),
	(min-device-width: 768px) and (max-device-width: 1024px)  {
	
		/* Force table to not be like tables anymore */
		table, thead, tbody, th, td, tr { 
			display: block; 
			text-align:right;
		}
		
		/* Hide table headers (but not display: none;, for accessibility) */
		thead tr { 
			position: absolute;
			top: -9999px;
			left: -9999px;
			text-align:right;
			
		}
		
		tr { border: 5px solid #ccc; 
		}
		
		td { 
			/* Behave  like a "row" */
			border: 1px solid #ddd;
			border-bottom: 1px solid #eee; 
			position: relative;
			padding-right: 50%;			
			text-align:right;
			direction:rtl;
		}
		
		td:before { 
			/* Now like a table header */
			position: absolute;
			/* Top/left values mimic padding */
			top: 6px;
			right: 6px;
			width: 45%; 
			text-align:right;
			padding-left: 10px; 
			white-space: nowrap;
			direction:rtl;
		}
		
		/*
		Label the data
		*/
		td:nth-of-type(1):before { content: "מספר דירה"; }
		td:nth-of-type(2):before { content: "שם דייר"; }
		td:nth-of-type(3):before { content: "ינואר"; }
		td:nth-of-type(4):before { content: "פברואר"; }
		td:nth-of-type(5):before { content: "מרץ"; }
		td:nth-of-type(6):before { content: "אפריל"; }
		td:nth-of-type(7):before { content: "מאי"; }
		td:nth-of-type(8):before { content: "יוני"; }
		td:nth-of-type(9):before { content: "יולי"; }
		td:nth-of-type(10):before { content: "אוגוסט"; }
		td:nth-of-type(11):before { content: "ספטמבר"; }
		td:nth-of-type(12):before { content: "אוקטובר"; }
		td:nth-of-type(13):before { content: "נובמבר"; }
		td:nth-of-type(14):before { content: "דצמבר"; }
	}
	
	/* Smartphones (portrait and landscape) ----------- */
	@media only screen
	and (min-device-width : 320px)
	and (max-device-width : 480px) {
		body { 
			padding: 0; 
			margin: 0; 
			width: 320px;
			direction:rtl;			}
		}
	
	/* iPads (portrait and landscape) ----------- */
	@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) {
		body { 
			width: 495px; 
			direction:rtl;
		}
	}
	
	</style>
	<!--<![endif]-->

</head>

<body>

	<div id="page-wrap">
	<script>
	
	</script>
	<h1 class="example" style="text-align:center"><?php echo $choice ?></h1>
	<script>
	chooseBuilding
	</script>
	</br>
	<center>
	<form name="optionSelection" dir="rtl" method="post">
	בחר בניין:
	<select name="buildings_name" onchange="this.form.submit();">
	<option></option>
	<?php
                  $result = mysql_query("SELECT * FROM buildings",$link);
                  while($row = mysql_fetch_array($result)) {
                    echo '<option name="'.$row['Address'].'">'.$row['Address'].'</option>';
                  }
	
	
	?>
	<!--<option>Google Chrome</option>
	<option>Firefox</option>  
	<option>Internet Explorer</option>
	<option>Safari</option>
	<option>Opera</option>!-->
	</select>
	</form>
	
	</center>
	</br>
	<form name="updateTable"  id="updateTable" action="check_pressed.php" method="post" accept-charset="UTF-8">
	<table dir="rtl">
		<thead>
		<tr>
			<th style="text-align:right">מספר דירה</th>
			<th style="text-align:right">שם דייר</th>
			<th style="text-align:right">ינואר</th>
			<th style="text-align:right">פברואר</th>
			<th style="text-align:right">מרץ</th>
			<th style="text-align:right">אפריל</th>
			<th style="text-align:right">מאי</th>
			<th style="text-align:right">יוני</th>
			<th style="text-align:right">יולי</th>
			<th style="text-align:right">אוגוסט</th>
			<th style="text-align:right">ספטמבר</th>
			<th style="text-align:right">אוקטובר</th>
			<th style="text-align:right">נובמבר</th>
			<th style="text-align:right">דצמבר</th>
		</tr>
		
		</thead>
		<tbody>
		<!--<tr>!-->
		<?php
			$temp=$_SESSION["building_session"];
			$results= mysql_query("SELECT * FROM tenants WHERE building='".$temp."' ORDER BY appartent_number ASC",$link);
			$numResults = mysql_num_rows($results);
			//echo $numResults;
			if($numResults >0)
			{
	while($row = mysql_fetch_array($results)) {
	$rowCounter=$rowCounter+1;
	$hidden_name = $row['name'];
	$hidden_number = $row['appartent_number'];
	echo '<input type="hidden" name="rowCounter" value="'.$rowCounter.'">';
	echo '<input type="hidden" name="names[]" value="'.$hidden_name.'">';
	echo '<input type="hidden" name="appartment_numbers[]" value="'.$hidden_number.'">';
	echo "<tr>";
	echo '<td>' . $row['appartent_number'] . '</td>';
	echo '<td>' . $row['name'] . '</td>';
	echo '<td><input type="text" size="5px" name="jan14[]" value="'.$row['january14'].'" /></td>';
	echo '<td><input type="text" size="5px" name="feb14[]" value="'.$row['february14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="mar14[]" value="'.$row['march14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="apr14[]" value="'.$row['april14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="may14[]" value="'.$row['may14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="jun14[]" value="'.$row['june14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="jul14[]" value="'.$row['july14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="aug14[]" value="'.$row['august14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="sep14[]" value="'.$row['september14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="oct14[]" value="'.$row['october14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="nov14[]" value="'.$row['november14'].'"/></td>';
	echo '<td><input type="text" size="5px" name="dec14[]" value="'.$row['december14'].'"/></td>';
	echo "</tr>";
}
}
?>
		</tbody>
	</table>
	</br>
	<div style="text-align: center;">
	
	<input type="submit" name="cancel" value="יציאה">
<input type="submit" name="mail" value="שלח מייל">
<input type="submit" name="submit" value="שמור">
</div>
	
	

	</form>
	</div>
		
</body>

</html>