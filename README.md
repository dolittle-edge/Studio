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

## Running

Edge Studio uses MongoDB and needs it to be running. For the EventStore part, it relies on a specific version as there is
a breaking change that has not been supported in Dolittle yet.

Run Mongo as a daemon:

```shell
$ docker run -p 27017:27017 -d mongo:4.0.13
```

In addition, for all aspects of Edge Studio to working, we also need the Dolittle Runtime running. This is to handle
the metrics and time series. Open a shell:

```shell
$ cd Source/Runtime
$ ./start_runtime.sh
```

## Building the CLI locally

```bash
cd Source/Tooling/Plugin
# if packages not already installed
yarn
# specify your version in the package.json before building
yarn build
npm pack
# now you have a tarball which you can install to a project
```