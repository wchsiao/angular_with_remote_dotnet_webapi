export interface EFormServiceRequestTypeStatus {
  statusDateTime: Date;
  serverName: string;
  requestType: string;
  success: number;
  failed: number;
}