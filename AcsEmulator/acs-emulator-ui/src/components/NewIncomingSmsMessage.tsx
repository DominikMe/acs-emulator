export interface NewIncomingSmsMessageProps {
  from: string,
  to: string
}

export const NewIncomingSmsMessage = (props: NewIncomingSmsMessageProps) => {

  return (
    <div>
      <span>From:</span><span>{props.from}</span>
      <span>To:</span><span>{props.to}</span>
    </div>
  );
}