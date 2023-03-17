<?php
if (isset($_POST['Submit'])) {
	include_once 'dbh.inc.php';
	
	$first = mysqli_real_escape_string($conn, $_POST['First']);
	$last = mysqli_real_escape_string($conn, $_POST['Last']);
	$email = mysqli_real_escape_string($conn, $_POST['Email']);
	$uid = mysqli_real_escape_string($conn, $_POST['User ID']);
	$pwd = mysqli_real_escape_string($conn, $_POST['Password'])  ;
	
	// check for empty fields
	if (empty($first) || empty($last) || empty($email)|| empty($uid)|| empty($pwd) ) 
	{
	    header("Location: ../signup.php?signup=empty");
	    exit();
	
	} else {
		// check if input character are valid
		if(!preg_match("/^[a-zA-Z]*$/", $first) || !preg_match("/^[a-zA-Z]*$/", $last)){
        
		    header("Location: ../signup.php?signup=invalid");
	         exit();
           } else {
			   // check if email is valid
			   if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
				   
				   header("Location: ../signup.php?signup=email");
	               exit();
			   }
			   else {
				   $sql = "SELECT * FROM users WHERE user_uid='$uid'";
				   $result = mysqli_query($conn, $sql);
				   $resultCheck = mysqli_num_rows($result);
				   
				   if($resultCheck > 0) {
					 header("Location: ../signup.php?signup=usertaken");
	                  exit();   
				   }
				   else {
					   //hashing the password
					   $hashedPwd = password_hash($pwd, PASSWORD_DEFAULT);
					   //insert user info 
					   $sql = "INSERT INTO users (user_first, user_last, user_email, user_uid, user_pwd) VALUES ('$first', '$last', '$email', '$uid', '$hashedPwd');";
					   mysqli_query($conn, $sql);
					   header("Location: ../signup.php?signup=success");
	                  exit();   
				   }
			   }   
		   }
	}
} else {
	header("Location: ../signup.php");
	exit();
}
