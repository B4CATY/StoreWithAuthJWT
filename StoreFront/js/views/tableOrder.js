const tableOrderStart = `
<div id="tableOrders">
<div style="position:relative; top: 100px;">
            <div style="position: relative; left: 60px; width: 1200px;">
                <table class="table table-borderless bg-dark text-white-50">
                    <thead>
                        <tr class="text-center">
                            <th></th>
                            <th>Name</th>
                            <th>Category</th>
                            <th>Price</th>
                            <th>Quantity</th>
                        </tr>
                    </thead>
                    <tbody id="videocartTableId">
`

const tableOrderEnd = `
  </tbody>
                </table>
                <div class="m-5" style="position:relative; margin-bottom: 200px; right: 130px;">
                    <button style="position:relative; left:100px;" onclick="router.loadRoute('orders')" type="button"
                        class="btn btn-info btn-rounded btn-lg">
                        Back to orders list
                    </button>
                   
                </div>
            </div>
        </div>
        </div>
`