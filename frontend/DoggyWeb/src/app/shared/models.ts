export interface APIResponse<T> {
  isSuccess: boolean,
  data: T | null | undefined
}