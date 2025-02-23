import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product/product-list/product-list/product-list.component';

export const routes: Routes = [
    { path: "", component: AppComponent },
    { path: "products", component: ProductListComponent }
];
