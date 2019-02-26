# Dolittle Studio Edge Solution

## Cloning

This repository has sub modules, clone it with:

```text
$ git clone --recursive <repository url>
```

If you've already cloned it, you can get the submodules by doing the following:

```text
$ git submodule update --init --recursive
```

## Building

All the build things are from a submodule. To build, run one of the following:

Windows:

```text
$ Build\build.cmd
```

Linux / macOS

```text
$ Build\build.sh
```