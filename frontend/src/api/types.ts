export type PostType = 'default' | 'withFile'

export interface RequestsType {
  post: (url: string, data: unknown, type?: PostType) => Promise<any>
  get: (url: string) => any
  patch: (url: string, data: any) => Promise<any>
  /*
  put: (path: string, data: any) => any
  delete: (path: string, data: any) => any*/
}
