import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/'


  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}product`);
  }
}