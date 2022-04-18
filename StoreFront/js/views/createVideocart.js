const createVideocartViewStart = `
<div id="registerForm" class="vh-100">
<div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-dark text-white" style="border-radius: 1rem;">
                <div class="card-body p-5 text-center">

                    <div class="mb-md-5 mt-md-4 pb-5">

                        <h3 class="fw-bold mb-2 text-uppercase">Add new Videocart</h3>
                        <p class="text-white-50 mb-5">Please fill in the form!</p>

                        <div class="form-outline form-white mb-4">
                            <input type="name" name="name" id="typeNameX" class="form-control form-control-lg" />
                            <label class="form-label" for="typeNameX">Name</label>
                        </div>
                        <div class="form-outline form-white mb-4">
                            <select class="form-select bg-dark text-white" id="selectCategory" aria-label="Category">
                            
                                
                            
`;

const createVideocartViewStartEnd = `
                            </select>
                        </div>
                        <div class="form-outline form-white mb-4">
                            <input type="Price" name="Price" id="typePricedX" class="form-control form-control-lg" />
                            <label class="form-label" for="typePasswordX">Price</label>
                            <div id="errorPrice"></div>
                        </div>
                         <div class="form-outline form-white mb-4">
                            <input type="Img" name="Img" id="typeImgdX" class="form-control form-control-lg" />
                            <label class="form-label" for="typeImgdX">Img</label>
                            <div id="errorImg"></div>
                        </div>


                        <button class="btn btn-outline-light
                         btn-rounded ripple-surface btn-lg px-5"
                         onclick="creteVideocart();"
                         type="submit">Create</button>
                    </div>


                </div>
            </div>
        </div>
    </div>
</div>
`

async function createSelectCategory(){
    let selectCategoryHtml = ``;
    const categories = await GetCategories();
    for (const category of categories) {
        selectCategoryHtml+= createSelect(category).toString();
    }
    return selectCategoryHtml;
}
function createSelect(objcet){
    return `<option value="${objcet.id}">${objcet.name}</option>`;
}
