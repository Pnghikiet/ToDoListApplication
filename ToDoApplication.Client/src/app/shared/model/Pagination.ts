export interface Pagination<T>{
    pageSize: number
    pageIndex: number
    totalPages: number
    totalItem: number
    data: T
}