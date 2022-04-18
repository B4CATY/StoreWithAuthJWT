const createCategoryView = `
<div id="registerForm" class="vh-100">
<div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-dark text-white" style="border-radius: 1rem;">
                <div class="card-body p-3 text-center">

                    <div class="mb-md-5 mt-md-4 pb-5">
                        
                        <h4 class="fw-bold mb-2 text-uppercase">Creating category</h4>
                        <p class="text-white-50 mb-5">Please fill in the form!</p>

                        <div class="form-outline form-white mb-4">
                        
                            <input style="position:relative; left:30px; width: 350px;" "type="text"
                                name="name" id="formWhite"
                                class="form-control form-control-lg" />
                            <label style="left:60px;" for="formWhite" class="form-label">Name</label>
                            <div id="error"></div>
                        </div>


                        <button class="btn btn-outline-light btn-hover 
                        btn-rounded btn-lg px-5" 
                        onclick="createCategory()"
                        type="submit">Create</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
`;