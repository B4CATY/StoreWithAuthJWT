const changeName = 
  ` <div id="registerForm" class="vh-100">
<div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-dark text-white" style="border-radius: 1rem;">
                <div class="card-body p-3 text-center">

                    <div class="mb-md-5 mt-md-4 pb-5">
                        
                        <h4 class="fw-bold mb-2 text-uppercase">Changing Username</h4>
                        <p class="text-white-50 mb-5">Please enter your new username!</p>

                        <div class="form-outline form-white mb-4">
                            <input style="position:relative; left:50px; width: 300px; "type="name" name="name" id="typeNameX" class="form-control form-control-lg" />
                            <label style="left:60px;" class="form-label">New user name</label>
                            <div id="error"></div>
                        </div>


                        <button class="btn btn-outline-light btn-hover 
                        btn-rounded btn-lg px-5" 
                        onclick="editName();"
                        type="submit">Change</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>`;