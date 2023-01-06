import { EFormServiceStatus } from "./eform-service-status";

export interface EFormServiceEnvStatus {
  statusDateTime: Date;
  eFormServiceStatusList: EFormServiceStatus[]
}