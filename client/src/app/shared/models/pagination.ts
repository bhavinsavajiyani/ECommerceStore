export interface Pagination<T> {
    pageIndex: number;
    pageSize: number;
    productCount: number;
    data: T;
  }