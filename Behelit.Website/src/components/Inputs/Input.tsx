import { ChangeEventHandler } from 'react';
import styled from 'styled-components';

const StyledInput = styled.input<{ width: string }>`
  width: ${(props) => props.width};
  padding: 0.5rem 1rem;
  font-size: 12px;

  &:focus {
    outline: none;
  }
`;

interface Props {
  onChange?: ChangeEventHandler<HTMLInputElement>;
  placeholder?: string;
  type?: 'text' | 'password';
  width?: string;
}

const Input = ({ onChange, placeholder = '', type = 'text', width = '100%', ...rest }: Props) => (
  <StyledInput data-lpignore="true" placeholder={placeholder} type={type} width={width} {...rest} onChange={onChange} />
);

export default Input;
