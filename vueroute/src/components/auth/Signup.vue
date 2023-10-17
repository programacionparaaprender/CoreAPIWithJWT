<template>
<div>
	<div></div>


<div>
<div class="wrapper">
    <form class="form-signin" @submit.prevent>       
      <h2 class="form-signin-heading">Please Signup</h2>
      <label>Fullname</label>
	  <input v-model="yourname" type="text" class="form-control" name="fullname" placeholder="Fullname" />
      
      <button class="btn btn-lg btn-primary btn-block" type="submit" @click="fullname = yourname">Signup</button>   
	<p>{{ firstname }}</p>	
	</form>
  </div>
	</div>
	
	
</div>
</template>
<script>
export default{
	data(){
		return{
			yourname:"",
			firstname:"",
			lastname:""
		}
	},
	computed:{
		fullname:{
			get(){
				return this.firstname + ' ' + this.lastname;
			},
			set(value){
				var names = value.split(' ');
				this.firstname = names[0];
				this.lastname = names[1];
			}
		}
	},
	methods:{

	}
}
</script>
<style>


.wrapper {	
	margin-top: 80px;
  margin-bottom: 80px;
}

.form-signin {
  max-width: 380px;
  padding: 15px 35px 45px;
  margin: 0 auto;
  background-color: #fff;
  border: 1px solid rgba(0,0,0,0.1);  

  .form-signin-heading,
	.checkbox {
	  margin-bottom: 30px;
	}

	.checkbox {
	  font-weight: normal;
	}

	.form-control {
	  position: relative;
	  font-size: 16px;
	  height: auto;
	  padding: 10px;
		@include box-sizing(border-box);

		&:focus {
		  z-index: 2;
		}
	}

	input[type="text"] {
	  margin-bottom: -1px;
	  border-bottom-left-radius: 0;
	  border-bottom-right-radius: 0;
	}

	input[type="password"] {
	  margin-bottom: 20px;
	  border-top-left-radius: 0;
	  border-top-right-radius: 0;
	}
}

</style>
