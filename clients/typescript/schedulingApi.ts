// Keep in step with the C# records in src/Scheduling.Api.

/** The shared error envelope every Meridian API returns. */
export interface ApiErrorEnvelope {
  error: { code: SchedulingErrorCode | string; message: string; correlationId: string };
}

export type SchedulingErrorCode = 'APPOINTMENT_NOT_FOUND' | 'INVALID_LENGTH';

export interface Appointment {
  id: string;
  tenantId: string;
  providerId: string;
  patientRef: string;
  startsAt: string;
  minutes: number;
}

export interface BookAppointment {
  providerId: string;
  patientRef: string;
  startsAt: string;
  minutes: number;
}
