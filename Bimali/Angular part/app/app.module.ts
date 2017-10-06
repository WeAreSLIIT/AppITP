import { StocksService } from './services/stocks.service';
import { ReturnFromCustomerService } from './services/return-from-customer.service';
import { RecountTransactionComponent } from './components/stocks/recount-transaction/recount-transaction.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { AppComponent } from './app.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';
import { HandleEmployeesComponent } from './components/employee/handle-employees/handle-employees.component';
import { AddUserAccountComponent } from './components/user-account/add-user-account/add-user-account.component';
import { HandleUserAccountComponent } from './components/user-account/handle-user-account/handle-user-account.component';
import { AddBranchComponent } from './components/branches/add-branch/add-branch.component';
import { HandleBranchComponent } from './components/branches/handle-branch/handle-branch.component';
import { AddProductComponent } from './components/products/add-product/add-product.component';
import { ViewProductComponent } from './components/products/view-product/view-product.component';
import { HandleProductComponent } from './components/products/handle-product/handle-product.component';
import { HandleCategoryComponent } from './components/products/handle-category/handle-category.component';
import { HandleSectionComponent } from './components/sections/handle-section/handle-section.component';
import { HandleProductsSectionComponent } from './components/sections/handle-products-section/handle-products-section.component';
import { ViewProductsSectionComponent } from './components/sections/view-products-section/view-products-section.component';
import { ViewGiftVoucherComponent } from './components/gift-voucher/view-gift-voucher/view-gift-voucher.component';
import { AddGiftVoucherComponent } from './components/gift-voucher/add-gift-voucher/add-gift-voucher.component';
import { IssueGiftVoucherComponent } from './components/gift-voucher/issue-gift-voucher/issue-gift-voucher.component';
import { RedeemGiftVoucherComponent } from './components/gift-voucher/redeem-gift-voucher/redeem-gift-voucher.component';
import { PurchasedGiftVoucherComponent } from './components/gift-voucher/purchased-gift-voucher/purchased-gift-voucher.component';
import { DiscountTypesComponent } from './components/discount/discount-types/discount-types.component';
import { DiscountScheduleComponent } from './components/discount/discount-schedule/discount-schedule.component';
import { PromotionTypesComponent } from './components/promotion/promotion-types/promotion-types.component';
import { PromotionScheduleComponent } from './components/promotion/promotion-schedule/promotion-schedule.component';
import { AddSupplierComponent } from './components/suppliers/add-supplier/add-supplier.component';
import { EditSupplierComponent } from './components/suppliers/edit-supplier/edit-supplier.component';
import { ViewSupplierComponent } from './components/suppliers/view-supplier/view-supplier.component';
import { PaySupplierComponent } from './components/suppliers/pay-supplier/pay-supplier.component';
import { CheckoutSupplierPaymentComponent } from './components/suppliers/checkout-supplier-payment/checkout-supplier-payment.component';
import { ViewOrdersComponent } from './components/orders/view-orders/view-orders.component';
import { EditOrderComponent } from './components/orders/edit-order/edit-order.component';
import { RequestOrderComponent } from './components/orders/request-order/request-order.component';
import { ViewOrderListComponent } from './components/orders/view-order-list/view-order-list.component';
import { ViewStocksComponent } from './components/stocks/view-stocks/view-stocks.component';
import { AddStockComponent } from './components/stocks/add-stock/add-stock.component';
import { IssueGoodsComponent } from './components/stocks/issue-goods/issue-goods.component';
import { WastageStockComponent } from './components/stocks/wastage-stock/wastage-stock.component';
import { NewGrnComponent } from './components/stocks/new-grn/new-grn.component';
import { StockRecountComponent } from './components/stocks/stock-recount/stock-recount.component';
import { DeleteStockComponent } from './components/stocks/delete-stock/delete-stock.component';
import { AddCustomerComponent } from './components/cutomer/add-customer/add-customer.component';
import { ProfileComponent } from './components/cutomer/profile/profile.component';
import { PreOrderComponent } from './components/cutomer/pre-order/pre-order.component';
import { AddLoyaltyProgramComponent } from './components/loyalty-card/add-loyalty-program/add-loyalty-program.component';
import { HandleLoyaltyProgramComponent } from './components/loyalty-card/handle-loyalty-program/handle-loyalty-program.component';
import { HandleCustomersComponent } from './components/loyalty-card/handle-customers/handle-customers.component';
import { TransInStockComponent } from './components/stocks/trans-in-stock/trans-in-stock.component';
import { TransOutStockComponent } from './components/stocks/trans-out-stock/trans-out-stock.component';
import { ReturnToSupplierComponent } from './components/stocks/return-to-supplier/return-to-supplier.component';
import { ReturnFromCustomerComponent } from './components/stocks/return-from-customer/return-from-customer.component';
import { DiscountScheduleService } from './services/discount/discount-schedule/discount-schedule.service';
import { EditGiftVoucherComponent } from './components/gift-voucher/edit-gift-voucher/edit-gift-voucher.component';


const appRoutes: Routes = [

    {path : 'employee' , component : HandleEmployeesComponent },
    {path : 'employee/add' , component : AddEmployeeComponent },
    {path : 'employee/handle' , component : HandleEmployeesComponent },

    {path : 'branch' , component : HandleBranchComponent },
    {path : 'branch/add' , component : AddBranchComponent },
    {path : 'branch/handle' , component : HandleBranchComponent },

    {path : 'userAccount' , component : HandleUserAccountComponent },
    {path : 'userAccount/add' , component : AddUserAccountComponent},
    {path : 'userAccount/handle' , component : HandleUserAccountComponent },

    {path : 'products' , component : HandleProductComponent },
    {path : 'products/add' , component : AddProductComponent },
    {path : 'products/view' , component : ViewProductComponent },
    {path : 'products/handle' , component : HandleProductComponent },
    {path : 'products/category' , component : HandleCategoryComponent },

    {path : 'sections' , component : HandleSectionComponent },
    {path : 'sections/handle' , component : HandleSectionComponent },
    {path : 'sections/products' , component : HandleProductsSectionComponent },
    {path : 'sections/view' , component : ViewProductsSectionComponent },

    {path : 'giftVouchers' , component : ViewGiftVoucherComponent },
    {path : 'giftVouchers/view' , component : ViewGiftVoucherComponent },
    {path : 'giftVouchers/add' , component : AddGiftVoucherComponent },
    {path : 'giftVouchers/edit', component : EditGiftVoucherComponent},
    {path : 'giftVouchers/issue' , component : IssueGiftVoucherComponent },
    {path : 'giftVouchers/redeem' , component : RedeemGiftVoucherComponent },
    {path : 'giftVouchers/purchased' , component : PurchasedGiftVoucherComponent },

    {path : 'discount/types' , component : DiscountTypesComponent },
    {path : 'discount/schedule' , component : DiscountScheduleComponent },

    {path : 'promotion/types' , component : PromotionTypesComponent },
    {path : 'promotion/schedule' , component : PromotionScheduleComponent },

    {path : 'supplier' , component : ViewSupplierComponent },
    {path : 'supplier/add' , component : AddSupplierComponent },
    {path : 'supplier/edit' , component : EditSupplierComponent },
    {path : 'supplier/view' , component : ViewSupplierComponent },
    {path : 'supplier/pay' , component : PaySupplierComponent },
    {path : 'supplier/checkout' , component : CheckoutSupplierPaymentComponent },

    {path : 'orders' , component : ViewOrderListComponent},
    {path : 'orders/stat' , component : ViewOrderListComponent},
    {path : 'orders/view' , component : ViewOrdersComponent},
    {path : 'orders/edit' , component : EditOrderComponent},
    {path : 'orders/request' , component : RequestOrderComponent},

    {path : 'stocks' , component : ViewStocksComponent},
     // {path : 'stocks/view' , component : ViewStocksComponent},
    {path : 'stocks/issue' , component : IssueGoodsComponent},
    {path : 'stocks/add' , component : AddStockComponent},
    {path : 'stocks/transin' , component : TransInStockComponent},
    {path : 'stocks/transout' , component : TransOutStockComponent},
    {path : 'stocks/returnToSupplier' , component : ReturnToSupplierComponent},
    {path : 'stocks/returnFromCustomer' , component : ReturnFromCustomerComponent},
    {path : 'stocks/wastage' , component : WastageStockComponent},
    {path : 'stocks/newgrn' , component : NewGrnComponent},
    {path : 'stocks/recountTransaction', component : RecountTransactionComponent},
    {path : 'stocks/recount' , component : StockRecountComponent},
    {path : 'stocks/delete' , component : DeleteStockComponent},

    {path : 'customer/register' , component : AddCustomerComponent},
    {path : 'customer/profile' , component : ProfileComponent},
    {path : 'customer/preorder' , component : PreOrderComponent},

    {path : 'loyalty' , component : HandleLoyaltyProgramComponent},
    {path : 'loyalty/customers' , component : HandleCustomersComponent},
    {path : 'loyalty/add' , component : AddLoyaltyProgramComponent},
    {path : 'loyalty/handle' , component : HandleLoyaltyProgramComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    SideMenuComponent,
    AddEmployeeComponent,
    HandleEmployeesComponent,
    AddUserAccountComponent,
    HandleUserAccountComponent,
    AddBranchComponent,
    HandleBranchComponent,
    AddProductComponent,
    ViewProductComponent,
    HandleProductComponent,
    HandleCategoryComponent,
    HandleSectionComponent,
    HandleProductsSectionComponent,
    ViewProductsSectionComponent,
    ViewGiftVoucherComponent,
    AddGiftVoucherComponent,
    IssueGiftVoucherComponent,
    RedeemGiftVoucherComponent,
    PurchasedGiftVoucherComponent,
    DiscountTypesComponent,
    DiscountScheduleComponent,
    PromotionTypesComponent,
    PromotionScheduleComponent,
    AddSupplierComponent,
    EditSupplierComponent,
    ViewSupplierComponent,
    PaySupplierComponent,
    CheckoutSupplierPaymentComponent,
    ViewOrdersComponent,
    EditOrderComponent,
    RequestOrderComponent,
    ViewOrderListComponent,
    ViewStocksComponent,
    AddStockComponent,
    IssueGoodsComponent,
    WastageStockComponent,
    NewGrnComponent,
    StockRecountComponent,
    DeleteStockComponent,
    AddCustomerComponent,
    ProfileComponent,
    PreOrderComponent,
    AddLoyaltyProgramComponent,
    HandleLoyaltyProgramComponent,
    HandleCustomersComponent,
    TransInStockComponent,
    TransOutStockComponent,
    ReturnToSupplierComponent,
    ReturnFromCustomerComponent,
    EditGiftVoucherComponent,
    RecountTransactionComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpModule

  ],
  providers: [DiscountScheduleService, ReturnFromCustomerService, StocksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
