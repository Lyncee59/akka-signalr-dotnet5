import { DefaultTheme } from 'styled-components';

const theme: DefaultTheme = {
  colors: {
    primary: '#98BAD5',
    secondary: '#C6D3E3',
    tertiary: '#304674',
    quaternary: '#B2CBDE',
    quinary: '#D8E1E8',
    success: '#77AB59',
    successHighlight: '#36802D',
    error: '#FF6666',
    errorHighlight: '#FF3232',
    typography: '#404040',
    white: '#FFFFFF',
  },
  breakpoints: {
    sm: '768px',
    md: '1024px',
    lg: '1200px',
  },
} as const;

export default theme;
