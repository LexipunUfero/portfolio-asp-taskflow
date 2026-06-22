module.exports = {
  root: true,
  env: {
    browser: true,
    es2021: true,
  },

  parser: '@typescript-eslint/parser',

  plugins: ['react', 'react-hooks', '@typescript-eslint', 'import'],

  extends: [
    'eslint:recommended',
    'plugin:react/recommended',
    'plugin:react-hooks/recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:import/recommended',
    'plugin:import/typescript',
    'prettier',
  ],

  settings: {
    react: {
      version: 'detect',
    },
    'import/resolver': {
      typescript: {},
    },
  },

  rules: {
    'no-console': 'warn',
    'no-debugger': 'error',
    'no-unused-vars': 'off',
    '@typescript-eslint/no-unused-vars': ['warn'],

    eqeqeq: 'error',
    curly: 'error',

    'react/react-in-jsx-scope': 'off',
    'react/self-closing-comp': 'warn',
    'react/jsx-boolean-value': ['warn', 'never'],
    'react/jsx-curly-brace-presence': ['warn', 'never'],

    'react-hooks/rules-of-hooks': 'error',
    'react-hooks/exhaustive-deps': 'warn',

    'import/order': [
      'warn',
      {
        groups: ['builtin', 'external', 'internal'],
        'newlines-between': 'always',
      },
    ],

    '@typescript-eslint/no-explicit-any': 'warn',
    '@typescript-eslint/consistent-type-imports': 'warn',
  },
}
