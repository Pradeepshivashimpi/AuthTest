import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../../_models/product';
import { ProductService } from '../../../services/product.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  data: Product[] = [];
  private productService = inject(ProductService);

  ngOnInit(): void {
    this.getData();
  }

  getData(): void {
    this.productService.getProducts().subscribe({
      next: (products) => {
        this.data = products;
        console.log('Products:', products);
      },
      error: (err) => console.error('Error fetching products:', err)
    });
  }
}
